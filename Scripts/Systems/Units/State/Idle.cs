using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Idle : AIState
{  
    public Idle(AI ai) : base(ai){
        name = "Idling";
        
        if(idleRoutines.isIdling == false)
            ai.StartCoroutine(idleRoutines.Idle(ai));
    }

    public override void Update(){
        if(idleRoutines.isIdling == false)
            ai.StartCoroutine(idleRoutines.Idle(ai));

        if(idleRoutines.isHealing == false && ai.health < 100)
            ai.StartCoroutine(idleRoutines.Heal(ai));
    }

    public override void SetState(){

        if(AIUtils.AmountIn(ai.awareSphere) > 0)
            ai.state = new Tracking(ai);
        
    }
}
