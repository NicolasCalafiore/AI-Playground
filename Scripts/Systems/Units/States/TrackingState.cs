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

    public override void SetState(){
        if(unit.UnitsInSphere(unit.awarenessSphere) == 0)
            unit.state = new HoldingState(unit);
        
        if(unit.UnitsInSphere(unit.engageSphere) > 0)
            unit.state = new EngageState(unit);
    }


    public override void Update(){
        unit.navMeshAgent.SetDestination(unit.target.transform.position);
    }

    
    public override void UpdateStateUI(){
        unit.stanceText.text = "Tracking";
        unit.stanceText.color = Color.yellow;
    }
}
