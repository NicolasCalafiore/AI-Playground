using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public static class UnitUtils
{
    public static GameObject FindBed(){
        GameObject[] beds = GameObject.FindGameObjectsWithTag("Bed");
        foreach (GameObject bed in beds){
            if (!bed.GetComponent<Bed>().occupied){
                bed.GetComponent<Bed>().occupied = true;
                return bed;
            }
        }
        return null;
    }
    public static GameObject FindClosestTag(GameObject unit, string tag){
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = unit.transform.position;
        foreach (GameObject obj in objects){
            Vector3 diff = obj.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance){
                closest = obj;
                distance = curDistance;
            }
        }
        return closest;
    }   

    public static Vector3 GetRandomLocationInRadius(Vector3 origin, float radius){
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += origin;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, radius, 1);
        return hit.position;
    }


    public static float GetRandomFloat(float min = 0, float max = 100)
    {
        return UnityEngine.Random.Range(min, max);
    }

    public static int GetRandomInt(int min = 0, int max = 100)
    {
        return UnityEngine.Random.Range(min, max);
    }

}
