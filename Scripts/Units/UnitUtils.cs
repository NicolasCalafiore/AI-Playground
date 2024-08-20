using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public static class UnitUtils
{
    public static GameObject FindHouse(){
        
        GameObject[] houses = GameObject.FindGameObjectsWithTag("House");
        foreach (GameObject house in houses)
            if (!house.GetComponent<House>().occupied){
                house.GetComponent<House>().occupied = true;
                return house;
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

    public static Vector3 SetMeetingPoint(GameObject unit){

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Unit");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = unit.transform.position;

        foreach (GameObject obj in objects){
            if(!obj.GetComponent<Unit>().actionManager.action.socializable) continue;

            Vector3 diff = obj.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance){
                closest = obj;
                distance = curDistance;
            } 
        }

        if (closest != null){
            Vector3 middlePoint = (position + closest.transform.position) / 2;
            return middlePoint;
        }

        return Vector3.zero;
    }   

    public static Vector3 GetRandomLocationInRadius(Vector3 origin, float radius){
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += origin;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, radius, 1);
        return hit.position;
    }


    public static float GetRandomFloat(float min = 0, float max = 100) => UnityEngine.Random.Range(min, max);
    

    public static int GetRandomInt(int min = 0, int max = 100) => UnityEngine.Random.Range(min, max);

    internal static List<Unit> GetUnitsInRadius(Vector3 position, int v)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Unit");
        List<Unit> units = new List<Unit>();
        foreach (GameObject obj in objects){
            Vector3 diff = obj.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < v){
                units.Add(obj.GetComponent<Unit>());
            } 
        }
        return units;
    }
}
