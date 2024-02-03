using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelect : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    [SerializeField] 
    private Unit curUnit;
    public Unit CurUnit { get { return curUnit; } }

    private Camera cam;
    private Faction faction;

    public static UnitSelect instance;

    private void Awake()
    {
        faction = GetComponent<Faction>();
    }

    private void Start()
    {
        cam = Camera.main;
        layerMask = LayerMask.GetMask("Unit", "Building", "Resource", "Ground");

        instance = this;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ClearEverything();
            Debug.Log("Clear Everything");
        }

        if (Input.GetMouseButtonUp(0))
        {
            TrySelect(Input.mousePosition);
            
        }
    }

    private void SelectUnit(RaycastHit hit)
    {
        curUnit = hit.collider.GetComponent<Unit>();

        curUnit.ToggleSelectionVisual(true);

        Debug.Log("Selected Unit");
    }

    private void TrySelect(Vector2 _screenPos)
    {
        Ray ray = cam.ScreenPointToRay(_screenPos);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            switch (hit.collider.tag)
            {
                case "Unit":
                    SelectUnit(hit);
                    break;
            }
        }
    }

    private void ClearAllSelectionVisual()
    {
        if(curUnit != null)
            curUnit.ToggleSelectionVisual(false);
    }

    private void ClearEverything()
    {
        ClearAllSelectionVisual();
        curUnit = null;
    }
}