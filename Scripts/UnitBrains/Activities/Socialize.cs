using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Socialize : Activity
{
    public bool IsSocializing = false;
    public Socialize(Unit actor) : base(actor)
    {
        IsDone = false;
        Target = UnitUtils.FindClosestTag(Actor, "Center").transform.position;
    }

    public override void Execute()
    {
        Actor.MoveToPosition(Target);
    }

    public override void Update()
    {
        _TickManager.Tick();
        if(Vector3.Distance(Actor.transform.position, Target) < 5){
            IsSocializing = true;
        }
        
    }

    public override void TickCycle()
    {
        if(IsSocializing){
            Actor.needs.EnableSocialEffect = false;
            Actor.needs.Social -= 10;
            if(Actor.needs.Social <= 0){
                Actor.needs.EnableSocialEffect = true;
                IsDone = true;
            }
        }
    }
}