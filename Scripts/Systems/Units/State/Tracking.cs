using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : AIState
{  
    public Tracking(AI ai) : base(ai){
        name = "Tracking";
        ai.target = AIUtils.GetClosestUnit(ai.awareSphere, ai);
    }

    public override void Update(){
        if(ai.target == null) return;
        Debug.Log("Tracking");
        ai.navAgent.SetDestination(ai.target.transform.position);
    }

    public override void SetState(){
        if(AIUtils.AmountIn(ai.awareSphere) == 0)
            ai.state = new Idle(ai);

        if(AIUtils.AmountIn(ai.engageSphere) > 0)
            ai.state = new Engage(ai);
        
    }





}
