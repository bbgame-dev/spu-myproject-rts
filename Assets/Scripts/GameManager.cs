using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Faction myFaction;
    public Faction MyFaction { get { return myFaction; } }

    [SerializeField] private Faction enemyFaction;
    public Faction EnemyFaction { get { return enemyFaction; } }

    [SerializeField] private Faction[] factions;
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        MainUI.instance.UpdateAllResource(myFaction);
    }
}
