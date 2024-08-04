using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleRoutines
{  
    public bool isIdling = false;
    public bool isHealing = false;
    private int idlingDistance = 15;
    public IdleRoutines(){

    }

    
    public IEnumerator Idle(AI ai){
        isIdling = true;
        float posX = ai.transform.position.x + Random.Range(-idlingDistance, idlingDistance);
        float posZ = ai.transform.position.z + Random.Range(-idlingDistance, idlingDistance);
        ai.navAgent.SetDestination(new Vector3(posX, ai.transform.position.y, posZ));
        yield return new WaitUntil(() => ai.navAgent.pathStatus == NavMeshPathStatus.PathComplete);
        yield return new WaitForSeconds(Random.Range(0, 10));
        isIdling = false;
    }

    public IEnumerator Heal(AI ai){
        isHealing = true;
        ai.health += 10;
        yield return new WaitForSeconds(ai.healSpeed);
        isHealing = false;
    }
}
