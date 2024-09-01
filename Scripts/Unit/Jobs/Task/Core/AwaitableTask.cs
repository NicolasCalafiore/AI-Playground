using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class AwaitableTask : JobTask{   
    
    protected bool isStarted = false;
    protected float waitTime = 5;
    protected float timeWaited = 0;

    public AwaitableTask(Unit unit) : base(unit){
        
    }
    

}