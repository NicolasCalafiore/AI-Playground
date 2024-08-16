using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : Action
{
    public Vector3 target;
    public bool canStop = false;

    public Idle(Unit unit) : base(unit){
        target = UnitUtils.GetRandomLocationInRadius(unit.transform.position, 20);
        Debug.Log("Idle Point: " + target);
    }

    public override void Execute(){
            unit.GetComponent<Unit>().agent.SetDestination(target);
    }

    public override void Update(){
        if (unit.GetComponent<Unit>().agent.remainingDistance <= .5f){
            Debug.Log("Idle Point Reached");
            isDone = true;
        }
    }

}
