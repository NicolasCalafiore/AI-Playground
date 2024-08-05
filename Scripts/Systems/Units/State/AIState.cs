using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIState
{  
    public string name;
    public AI ai;
    public IdleRoutines idleRoutines = new IdleRoutines();
    public EngageRoutines engageRoutines = new EngageRoutines();
    public FleeRoutines fleeRoutines = new FleeRoutines();
    public int outputValue = 0;
    
    public AIState(AI ai){
        this.ai = ai;
    }

    public abstract void Update();
    public abstract void SetState();

}
