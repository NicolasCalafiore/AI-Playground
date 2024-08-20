using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : Action
{
    public Vector3 target;
    public override int Priority {get{return 2;}}
    public override int SatisfactionLevel {get{return 0;}}
    private float timeSinceLastUpdate = 0f;
    private float updateInterval = 2f;

    public Idle(Unit unit) : base(unit){
        isDone = false;
        target = UnitUtils.GetRandomLocationInRadius(unit.transform.position, 20);
         unit.transform.Find("Body").GetComponent<MeshRenderer>().material.color = Color.cyan;
    }

    public override void Execute(){
            unit.GetComponent<Unit>().agent.SetDestination(target);
    }

    public override void Update(){

        if (unit.GetComponent<Unit>().agent.remainingDistance <= .5f)
            PointReached();

        Tick();
        
    }

    public override void Tick(){
        timeSinceLastUpdate += Time.deltaTime;
        
        if(timeSinceLastUpdate >= updateInterval){
            timeSinceLastUpdate = 0f;
        }
    }

    private void PointReached(){
        isDone = true;
    }

}
