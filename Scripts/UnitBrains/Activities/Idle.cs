using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Idle : Activity
{
    
    public Idle(Unit actor) : base(actor)
    {
        IsDone = false;
        Target = UnitUtils.GetRandomLocationInRadius(Actor.transform.position, 10);
    }

    public override void Execute()
    {
        Actor.MoveToPosition(Target);
    }

    public override void Update()
    {
        
        if(Vector3.Distance(Actor.transform.position, Target) < 1){
            IsDone = true;
        }
    }

    public override void TickCycle()
    {
        Debug.Log("Idle Tick Cycle");
    }
}