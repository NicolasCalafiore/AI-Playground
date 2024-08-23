using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnitManager : MonoBehaviour
{
    [SerializeField] private int unitCount;

    void Start()
    {
        SpawnUnits();
    }

    void SpawnUnits(){
        for (int i = 0; i < unitCount; i++)
        {
            Vector3 spawnPosition = UnitUtils.GetValidSpawn();
            GameObject unitObject = Instantiate(IOManager.GetUnitPrefab(), spawnPosition, Quaternion.identity);
        }
    }

}
