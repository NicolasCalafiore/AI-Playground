using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class TrackingState : UnitState
{

    public TrackingState(Unit unit) : base(unit)
    {
        unit.target = unit.GetClosestUnit(unit.awarenessSphere);
        unit.navMeshAgent.stoppingDistance = 20f;

    }

    public override void SetStance(){
        if(unit.UnitsInSphere(unit.awarenessSphere) == 0)
            unit.state = new HoldingState(unit);
        
        if(unit.UnitsInSphere(unit.engageSphere) > 0)
            unit.state = new EngageState(unit);
    }


    public override void Update(){
        unit.navMeshAgent.SetDestination(unit.target.transform.position);
    }
}
