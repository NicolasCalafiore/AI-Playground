

// using UnityEngine;

// public class Flee : AIState
// {  
//     public Flee(AI ai) : base(ai)
//     {
//         name = "Fleeing";
//         Debug.Log("Fleeing");
//         ai.target = AIUtils.GetClosestUnit(ai.awareSphere, ai);
//         ai.StopAllCoroutines();
//         ai.StartCoroutine(fleeRoutines.Flee(ai));
//     }

//     public override void Update()
//     {  
//         // Keep the update logic simple
//     }

//     public override void SetState()
//     {
//         if (fleeRoutines.isFleeing) return;

//         if (AIUtils.AmountIn(ai.awareSphere) == 0)
//         {
//             ai.state = new Idle(ai);
//             return;
//         }

//         if (AIUtils.AmountIn(ai.engageSphere) > 0)
//         {
//             ai.state = new Engage(ai);
//             return;
//         }


//     }
// }
