using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Job
{
 
    public GameObject jobLocation;
    public Vector3 target;
    public int pay;
    public int startHour;
    public int endHour;
    public bool onBreak = false;
    public string outfit;
    public bool taskDone = true;

    public Job()
    {

    }

    public abstract void FindTask(Unit unit);
    public abstract void Update(Unit unit);


}
