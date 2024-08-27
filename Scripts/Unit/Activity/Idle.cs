using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle: Activity{

    public Idle(Unit unit): base(unit){
        
    }
    public override void Start(){
        TargetVector = UnitUtils.GetRandomLocationInRadius(unit.gameObject.transform.position, 15);
        unit.GetComponent<NavMeshAgent>().SetDestination(TargetVector);
    }
    public override void Update(){
        if(Vector3.Distance(unit.gameObject.transform.position, TargetVector) < 1){
           End();
        }
    }
    public override void End(){
        IsFinished = true;
    }
}