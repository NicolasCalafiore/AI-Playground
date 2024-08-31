using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Activity{
    protected Unit unit;
    public bool IsFinished = false;
    public Activity(Unit unit){
        this.unit = unit;
    }
    public abstract void Start();
    public abstract void Update();
    public abstract void End();
}