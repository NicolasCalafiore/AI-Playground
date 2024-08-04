using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EngageRoutines
{  
    public bool isEngaging = false;

    public EngageRoutines(){

    }

    
    public IEnumerator Engage(AI ai){
        isEngaging = true;
        ai.target.GetComponent<AI>().health -= ai.attackDamage;
        yield return new WaitForSeconds(ai.attackSpeed);
        isEngaging = false;
    }
}
