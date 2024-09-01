using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sleep: Activity{
    float UpdateInterval = 2f;
    float TimeSinceLastUpdate = 0f;
    bool IsSleeping = false;

    public Sleep(Unit unit): base(unit){
        
    }
    public override void Start(){
        unit.MoveToStructure(unit.home);
    }
    public override void Update(){

        TimeSinceLastUpdate += Time.deltaTime;

        if(Vector3.Distance(unit.gameObject.transform.position, unit.targetPosition) < 3 && !IsSleeping){
            IsSleeping = true;
            unit.EnterStructure(unit.home);
        }

        if(TimeSinceLastUpdate >= UpdateInterval && IsSleeping){
            TimeSinceLastUpdate = 0f;
            unit.GetComponent<Needs>().GoToSleep();
            unit.GetComponent<Needs>().energy.isActive = false;
        }

        if(unit.GetComponent<Needs>().IsFullyRested()){
            End();
        }
        
    }
    public override void End(){
        
        IsFinished = true;
        unit.ExitStructure();
        unit.GetComponent<Needs>().energy.isActive = true;
    }
}