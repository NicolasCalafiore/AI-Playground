using System;
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
        // UnitManager.OnSetStance += SetStance;
        unit.target.GetComponent<Unit>().OnDeath += TargetDeath;
        unit.StartCoroutine(UnitCoroutines.Attack(unit));
    }

    public override void SetState(){

    }
    
    public override void Update(){
    }


    public override void UpdateStateUI(){
        unit.stanceText.text = "Engaging";
        unit.stanceText.color = Color.red;
    }

    public void TargetDeath(){
        unit.state = new HoldingState(unit);
    }

    
}
