using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class Sleep : Action
{
    public Vector3 target;
    public bool canStop = false;
    private float timeSinceLastUpdate = 0f;
    private float updateInterval = 2f;
    private int sleepStrength = UnitUtils.GetRandomInt(3, 15);

    public Sleep(Unit unit) : base(unit){
        target = unit.bed.transform.position;
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
            unit.GetComponent<Unit>().bed.transform.Find("Sleeping").gameObject.SetActive(true);
            unit.transform.Find("Body").gameObject.GetComponent<MeshRenderer>().enabled = false;
            // Check if enough time has passed to run the function
            if (timeSinceLastUpdate >= updateInterval)
            {
                // Run your function
                unit.GetComponent<Unit>().energy.Value += sleepStrength;

                // Reset the timer
                timeSinceLastUpdate = 0f;
            }
        }

        if(unit.GetComponent<Unit>().energy.Value >= 100){
            unit.GetComponent<Unit>().bed.transform.Find("Sleeping").gameObject.SetActive(false);
             unit.transform.Find("Body").gameObject.GetComponent<MeshRenderer>().enabled = true;
            isDone = true;
        }
    }



}
