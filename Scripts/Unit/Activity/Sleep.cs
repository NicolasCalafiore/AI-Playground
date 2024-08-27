using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sleep: Activity{
    float UpdateInterval = 1f;
    float TimeSinceLastUpdate = 0f;
    bool IsSleeping = false;

    public Sleep(Unit unit): base(unit){
        
    }
    public override void Start(){
        TargetVector = unit.MoveToStructure(unit.home);
    }
    public override void Update(){
        TimeSinceLastUpdate += Time.deltaTime;

        if(Vector3.Distance(unit.gameObject.transform.position, TargetVector) < 3 && !IsSleeping){
            IsSleeping = true;
            unit.EnterStructure(unit.home);
        }

        if(TimeSinceLastUpdate >= UpdateInterval && IsSleeping){
            TimeSinceLastUpdate = 0f;
            unit.GetComponent<Needs>().GoToSleep();
        }

        if(unit.GetComponent<Needs>().IsFullyRested()){
            End();
        }
        
    }
    public override void End(){
        IsFinished = true;
        unit.ExitStructure();
    }
}