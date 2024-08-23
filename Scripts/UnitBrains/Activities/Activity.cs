using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Activity
{
    protected Vector3 Target;
    protected Unit Actor;
    public bool IsDone;
    protected TickManager _TickManager = new TickManager(1);


    public Activity(Unit actor)
    {
        Actor = actor;
         _TickManager.Ticked += TickCycle;
    }

    public abstract void Execute();
    public abstract void Update();

    public abstract void TickCycle();
    

}
