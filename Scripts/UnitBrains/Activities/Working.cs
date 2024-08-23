using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Working : Activity
{

    public Working(Unit actor) : base(actor)
    {
        IsDone = false;
        actor.WearOutfit(true);
        actor.job.isWorking = true;
    }

    public override void Execute()
    {
        Actor.GetComponent<Unit>().MoveToStructure(Actor.GetComponent<Unit>().job.JobLocation);
    }

    public override void Update()
    {
        _TickManager.Tick();
        if(Vector3.Distance(Actor.transform.position, Actor.job.JobLocation.transform.position) < 5){
            Actor.EnterStructure(Actor.job.JobLocation);
        }
        
    }

    public override void TickCycle()
    {

    }
}