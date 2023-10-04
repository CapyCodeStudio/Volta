using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public AttackState attackState;
    public bool isAttack;
    public override State RunCurrentState()
    {
        if (isAttack)
        {
            return attackState;
        }
        else
        {
            return this;
        }
        
    }
}
