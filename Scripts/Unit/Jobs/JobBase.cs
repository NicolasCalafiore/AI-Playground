using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class JobBase{
    public GameObject Location;
    protected int start;
    protected int end;
    public GameObject uniform;
    protected JobTask task;
    protected Structure structure;
    protected Unit unit;


    public JobBase( Unit unit){
        this.unit = unit;
    }

    public bool IsWorkingHours() => TimeManager.instance.hour >= start && TimeManager.instance.hour < end;
    public abstract void Update();
    

}