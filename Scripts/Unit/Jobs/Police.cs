using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : Job
{

    
    public Police(GameObject Actor) : base(Actor){
        Outfit = Resources.Load("Prefabs/Outfits/Police") as GameObject;
        StartHour = 0;
        EndHour = 24;
        JobLocation = GameObject.FindWithTag("Police");
    }

    public override void FindTask(){
        CurrentTask = new JobTask(UnitUtils.GetRandomLocationInRadius(Actor.transform.position, 50), 5, Actor, 1);
        CurrentTask.Execute();
    }

    public override void Update(){
        if(CurrentTask == null)
            FindTask();
        
        CurrentTask.Update();

        if(CurrentTask.isComplete){
            FindTask();
        }
    }
    
}
