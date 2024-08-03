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

    public override void SetState(){
        if(unit.UnitsInSphere(unit.awarenessSphere) > 0)
            unit.state = new TrackingState(unit);
        
        if(unit.UnitsInSphere(unit.engageSphere) > 0)
            unit.state = new EngageState(unit);
        
    }

    public override void Update(){

    }

    public override void UpdateStateUI(){
        unit.stanceText.text = "Holding";
        unit.stanceText.color = Color.blue;
    }

    
    
}
