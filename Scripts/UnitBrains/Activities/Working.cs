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
    }

    public override void Update()
    {
        _TickManager.Tick();
        Actor.job.Update();
    }

    public override void TickCycle()
    {
    }
}