using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EngageState : UnitState
{

    public EngageState(Unit unit) : base(unit)
    {
        unit.navMeshAgent.ResetPath();
        unit.navMeshAgent.velocity = Vector3.zero;
        GameObject threat = unit.GetClosestUnit(unit.engageSphere);
    }

    public override void SetStance(){

    }
    
    public override void Update(){

    }
}
