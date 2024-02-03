using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Structure
{
    [SerializeField] private Transform spawnPoint;
    public Transform SpawnPoint { get { return spawnPoint; } }

    [SerializeField] private Transform rallyPoint;
    public Transform RallyPoint { get { return rallyPoint; } }

    [SerializeField] private GameObject[] unitPrefabs;

    [SerializeField] private List<Unit> recruitList = new List<Unit>();

    [SerializeField] private float unitTimer = 0f;
    [SerializeField] private int curUnitProgress = 0;
    [SerializeField] private float curUnitWaitTime = 0;

    private void Start()
    {
        curHP = MaxHP;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            ToCreateUnit(0);

        if((recruitList.Count > 0 )&& (recruitList[0] != null))
        {
            unitTimer += Time.deltaTime;
            curUnitWaitTime = recruitList[0].UnitWaitTime;

            if(unitTimer >= curUnitWaitTime )
            {
                curUnitProgress++;
                unitTimer = 0f;

                if(curUnitProgress >= 100)
                {
                    curUnitProgress = 0;
                    curUnitWaitTime = 0;
                    CreateUnitCompleted();
                }
            }
        }



    }
    public void ToCreateUnit(int i)
    {
        Debug.Log(structureName + " create " + i + ":" + unitPrefabs.Length);

        if (unitPrefabs.Length == 0)
            return;

        if (unitPrefabs[i] == null)
            return;

        Unit unit = unitPrefabs[i].GetComponent<Unit>();

        if(unit == null) return;

        if(!faction.CheckUnitCost(unit)) return;  //not enouge resource

        //Deduct Resource
        faction.DeductUnitCost(unit);

        //if it's me, Update UI
        if (faction == GameManager.instance.MyFaction)
            MainUI.instance.UpdateAllResource(faction);

        //Add unit into faction's recruit list
        recruitList.Add(unit);

        Debug.Log("Adding" + i + "to Recruit List...");
            
    }

    public void CreateUnitCompleted()
    {
        int id = recruitList[0].ID;

        if (unitPrefabs[id] == null)
            return;

        GameObject unitObj = Instantiate(unitPrefabs[id], spawnPoint.position, Quaternion.Euler(0f,180f,0f));

        recruitList.RemoveAt(0);

        Unit unit = unitObj.GetComponent<Unit>();
        unit.MoveToPosition(rallyPoint.position); //Go to Rally Point

        //Add unit into faction's Army
        faction.AliveUnits.Add(unit);

        Debug.Log("Unit Recruited");

        //If it's me, Update UI
        if (faction == GameManager.instance.MyFaction)
            MainUI.instance.UpdateAllResource(faction);

    }

    public void ToggleSelectionVisual(bool flag)
    {
        if (selectionVisual != null)
            SelectionVisual.SetActive(flag);
    }


        
}
