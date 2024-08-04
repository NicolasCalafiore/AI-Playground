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
}
