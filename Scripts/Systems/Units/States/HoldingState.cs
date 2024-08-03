using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class HoldingState : UnitState
{
    public HoldingState(Unit unit) : base(unit)
    {
    }

    public override void SetStance(){
        if(unit.UnitsInSphere(unit.awarenessSphere) > 0)
            unit.state = new TrackingState(unit);
        
        if(unit.UnitsInSphere(unit.engageSphere) > 0)
            unit.state = new EngageState(unit);
        
    }

    public override void Update(){
    }
    
}
