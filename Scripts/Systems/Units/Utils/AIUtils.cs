using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class AIUtils
{  

    public static int AmountIn(GameObject sphere){
        Collider[] hitColliders = Physics.OverlapSphere(sphere.transform.position, sphere.transform.localScale.x / 2f);
        int count = 0;
        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Unit"))
            {
                count++;
            }
        }
        return count - 1;
    }

    public static GameObject GetClosestUnit(GameObject sphere, AI ai)
    {
        Collider[] colliders = Physics.OverlapSphere(sphere.transform.position, sphere.transform.localScale.x / 2);

        GameObject closestUnit = null;
        float closestDistance = Mathf.Infinity;
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag == "Unit" && collider.gameObject.transform.parent.gameObject != ai.gameObject)
            {
                float distance = Vector3.Distance(collider.transform.position, ai.gameObject.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestUnit = collider.gameObject.transform.parent.gameObject;
                }
            }
        }

        return closestUnit;
    }

    public static int EvaluateThreat(AI ai, AI target)
    {
        int level = 0;
        int expected_self_damage = target.attackDamage / target.attackSpeed;
        int expected_target_damage = ai.attackDamage / ai.attackSpeed;
        int expected_time_to_kill_target = target.health / expected_target_damage;
        int expected_time_to_kill_self = ai.health / expected_self_damage;

        Debug.Log("Expected time to kill target: " + expected_time_to_kill_target);
        Debug.Log("Expected time to kill self: " + expected_time_to_kill_self);
        

        if (expected_time_to_kill_self < expected_time_to_kill_target)
            level = -1;
        
        else if (expected_time_to_kill_self > expected_time_to_kill_target)
            level = 1;
        

        Debug.Log("Threat level: " + level);
        return level;
        
    }
}
