using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobTask
{
    private Vector3 target;
    private int timeToComplete;
    public bool isComplete;
    private GameObject actor;
    TickManager tickManager;
    int flagRadius;

    public JobTask(Vector3 target, int timeToComplete, GameObject actor, int radius)
    {
        this.target = target;
        this.timeToComplete = timeToComplete;
        this.actor = actor;
        this.flagRadius = radius;

        isComplete = false;
    }

    public void Execute()
    {
        actor.GetComponent<Unit>().MoveToPosition(target);
    }

    public void Update()
    {
        if (Vector3.Distance(actor.transform.position, target) < flagRadius)
        {
            isComplete = true;
        }
    }
}
