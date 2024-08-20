using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action
{
 
    public Vector3 target;
    public bool canStop = false;
    public Unit unit;
    public bool isDone = false;

    public abstract int SatisfactionLevel {get;}
    public abstract int Priority {get;}
    public bool socializable = false;
    public Action(Unit unit){
        this.unit = unit;
    }
    public abstract void Execute();
    public abstract void Update();
    public abstract void Tick();
    public void Stop(){
        unit.GetComponent<Unit>().agent.ResetPath();
        unit.GetComponent<Unit>().agent.speed = 0;
    }

}
