using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class JobTask{   
    public bool isFinished = false;
    protected Unit unit;
    
    public JobTask(Unit unit){
        this.unit = unit;
    }
    public abstract void Update();


    
}