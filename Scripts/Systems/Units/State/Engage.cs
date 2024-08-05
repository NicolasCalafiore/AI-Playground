using UnityEngine;

public class Engage : AIState
{  
    public Engage(AI ai) : base(ai)
    {
        name = "Engaging";
        ai.target = AIUtils.GetClosestUnit(ai.engageSphere, ai);
        ai.navAgent.ResetPath();
        ai.navAgent.velocity = Vector3.zero;


        
    }

    public override void Update()
    {
        if (!engageRoutines.isEngaging)
            ai.StartCoroutine(engageRoutines.Engage(ai));
    }

    public override void SetState()
    {
        if (AIUtils.AmountIn(ai.awareSphere) == 0)
        {
            ai.state = new Idle(ai);
            return;
        }

        if (AIUtils.AmountIn(ai.engageSphere) == 0)
        {
            ai.state = new Tracking(ai);
            return;
        }
    }
}
