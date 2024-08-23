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

    public void FindTask(){
        
    }

    public void Update(){

    }


    
}
