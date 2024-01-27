using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimation : MonoBehaviour
{
    private Animator anim;
    private Unit unit;


    private void Start()
    {
        anim = GetComponent<Animator>();
        unit = GetComponent<Unit>();
    }

    private void Update()
    {
        ChooseAnimation(unit);
    }

    private void ChooseAnimation(Unit _unit)
    {
        anim.SetBool("IsIdle", false);
        anim.SetBool("IsWalk", false);
        anim.SetBool("IsAttack", false);

        switch (_unit.State)
        {
            case UnitState.Idle:
                anim.SetBool("IsIdle", true);
                break;
            case UnitState.Move:
                anim.SetBool("IsWalk", true);
                break;
            case UnitState.Attack:
                anim.SetBool("IsAttack", true);
                break;
        }
    }
}
