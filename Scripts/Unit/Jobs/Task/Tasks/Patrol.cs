using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : VectorTask{   

    
    public Patrol(Unit unit) : base(unit){
        targetVector = UnitUtils.GetRandomLocationInRadius(unit.gameObject.transform.position, 40);
        unit.GoToVectorPosition(targetVector);
    }


    public override void Update()
    {
        if(Vector3.Distance(unit.gameObject.transform.position, targetVector) < 1){
            isFinished = true;
            return;
        }
    }


}