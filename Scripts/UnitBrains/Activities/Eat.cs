using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Eat : Activity
{
    bool IsEating = false;
    public Eat(Unit actor) : base(actor)
    {
        IsDone = false;
    }

    public override void Execute()
    {
        Debug.Log("Sleeping");
        Actor.MoveToStructure(UnitUtils.FindClosestTag(Actor, "Resturant"));
    }

    public override void Update()
    {
        _TickManager.Tick();
        if(!IsEating && Vector3.Distance(Actor.transform.position, Actor.targetStructure.transform.position) < 5){
            IsEating = true;
            Actor.EnterStructure(Actor.targetStructure);
        }
        
    }

    public override void TickCycle()
    {
        if(IsEating){
            Actor.needs.EnableHungerEffect = false;
            Debug.Log("Eating Tick");
            Actor.needs.Hunger -= 2;
            if(Actor.needs.Hunger <= 0){
                Actor.ExitStructure();
                Actor.needs.EnableHungerEffect = true;
                IsDone = true;
            }
        }
    }
}