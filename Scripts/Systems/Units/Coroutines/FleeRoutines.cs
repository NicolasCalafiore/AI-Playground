using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FleeRoutines
{  
    public bool isFleeing = false;

    public FleeRoutines()
    {
    }

    public IEnumerator Flee(AI ai)
    {
        isFleeing = true;
        ai.navAgent.SetDestination(new Vector3(0,0,0));
        yield return new WaitUntil(() => ai.navAgent.pathStatus == NavMeshPathStatus.PathComplete);
        isFleeing = false;
    }
}
