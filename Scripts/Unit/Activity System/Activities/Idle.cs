using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle: Activity{

    public Idle(Unit unit): base(unit){
        
    }
    public override void Start(){

        unit.GoToVectorPosition(UnitUtils.GetRandomLocationInRadius(unit.gameObject.transform.position, 15));
    }
    public override void Update(){

        if(Vector3.Distance(unit.gameObject.transform.position, unit.targetPosition) < 1)
           End();
        
    }
    public override void End(){
        
        IsFinished = true;
    }
}