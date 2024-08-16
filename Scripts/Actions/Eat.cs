using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : Action
{
    public Vector3 target;
    public bool canStop = false;
    private float timeSinceLastUpdate = 0f;
    private float updateInterval = 2f;
    private int appetiteStrength = UnitUtils.GetRandomInt(3, 15);

    public Eat(Unit unit) : base(unit){
        target = UnitUtils.FindClosestTag(unit.gameObject, "Stove").transform.position;
        Debug.Log("Eat Point: " + target);
    }

    public override void Execute(){
            unit.GetComponent<Unit>().agent.SetDestination(target);
    }

    public override void Update()
    {
        // Increment the timer with the time passed since last frame
        timeSinceLastUpdate += Time.deltaTime;

        // Check if the agent has reached the target
        if (unit.GetComponent<Unit>().agent.remainingDistance <= .5f)
        {
            // Check if enough time has passed to run the function
            if (timeSinceLastUpdate >= updateInterval)
            {
                // Run your function
                unit.GetComponent<Unit>().nourishment.Value += appetiteStrength;

                // Reset the timer
                timeSinceLastUpdate = 0f;
            }
        }

        if(unit.GetComponent<Unit>().nourishment.Value >= 75){
            isDone = true;
        }
    }

}
