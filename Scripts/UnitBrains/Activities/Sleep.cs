using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sleep : Activity
{
    bool IsSleeping = false;
    public Sleep(Unit actor) : base(actor)
    {
        IsDone = false;
    }

    public override void Execute()
    {
        Actor.MoveToStructure(Actor.GetHome());
    }

    public override void Update()
    {
        _TickManager.Tick();
        if(!IsSleeping && Vector3.Distance(Actor.transform.position, Actor.StructureDoorPosition(Actor.GetHome())) < 5){
            IsSleeping = true;
            Actor.EnterStructure(Actor.GetHome());
        }
        
    }

    public override void TickCycle()
    {
        if(IsSleeping){
            Actor.needs.EnableSleepEffect = false;
            Actor.needs.Sleep -= 10;
            if(Actor.needs.Sleep <= 0){
                Actor.ExitStructure();
                Actor.needs.EnableSleepEffect = true;
                IsDone = true;
            }
        }
    }
}