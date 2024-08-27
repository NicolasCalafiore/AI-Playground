using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public static class UnitUtils
{
    [SerializeField] private static Vector2 SpawnRange = new Vector2(100, 100);
    public static GameObject GetUnitPrefab()
    {
        return Resources.Load<GameObject>("Prefabs/Unit");
    }

    public static bool FindHousing(GameObject unit){
        House house = WorldRegister.GetAvailableHouse();

        if(house == null)
            return false;
        
        unit.GetComponent<Unit>().home = house;
        return true;
    }

    public static Vector3 GetValidSpawn(){
        Vector3 spawnPosition;
        bool positionIsValid = false;

        do
        {
            spawnPosition = new Vector3(Random.Range(0, SpawnRange.x), 0, Random.Range(0, SpawnRange.y));
            Collider[] colliders = Physics.OverlapSphere(spawnPosition, 1f); // Adjust the radius as needed

            if (colliders.Length == 1)
            {
                positionIsValid = true;
            }
        } while (!positionIsValid);

        return spawnPosition;
    }


    public static Vector3 GetRandomLocationInRadius(Vector3 origin, float radius){
        Vector3 randomPosition = Vector3.zero;
        NavMeshHit hit;
        bool positionIsValid = false;
        float safeDistanceFromEdge = 1f; // Distance from the edge of the NavMesh

        do {
            Vector3 randomDirection = Random.insideUnitSphere * radius;
            randomDirection += origin;

            if (NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas)) {
                randomPosition = hit.position;

                // Additional check: ensure the position is not too close to the edge of the NavMesh
                if (NavMesh.Raycast(randomPosition, randomPosition + Vector3.forward * safeDistanceFromEdge, out NavMeshHit edgeHit, NavMesh.AllAreas) ||
                    NavMesh.Raycast(randomPosition, randomPosition + Vector3.right * safeDistanceFromEdge, out edgeHit, NavMesh.AllAreas)) {
                    // If too close to the edge, continue the loop
                    continue;
                }

                Collider[] colliders = Physics.OverlapSphere(randomPosition, 1f);
                if (colliders.Length == 1) {
                    positionIsValid = true;
                }
            }
        } while (!positionIsValid);

        return randomPosition;
    }

    public static GameObject FindClosestTag(Unit unit, string tag){
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
}

