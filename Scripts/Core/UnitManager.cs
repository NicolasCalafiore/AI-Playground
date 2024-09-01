using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnitManager : MonoBehaviour
{
    [SerializeField] private int unitCount;
    [SerializeField] private int policeCount;
    [SerializeField] private int cookCount;

    void Start()
    {
        SpawnUnits();
    }

    void SpawnUnits(){

        for(int i = 0; i < unitCount; i++){
            GameObject unit = Instantiate(Resources.Load("Prefabs/Unit"), UnitUtils.GetValidSpawn(), Quaternion.identity) as GameObject;
            unit.transform.parent = gameObject.transform;
        }

        

        for(int i = 0; i < policeCount; i++){
            GameObject unit = Instantiate(Resources.Load("Prefabs/Unit"), UnitUtils.GetValidSpawn(), Quaternion.identity) as GameObject;
            unit.transform.parent = gameObject.transform;
            unit.GetComponent<Job>().SetJob(new Police(unit.GetComponent<Unit>()));
        }

        for(int i = 0; i < cookCount; i++){
            GameObject unit = Instantiate(Resources.Load("Prefabs/Unit"), UnitUtils.GetValidSpawn(), Quaternion.identity) as GameObject;
            unit.transform.parent = gameObject.transform;
            unit.GetComponent<Job>().SetJob(new Cook(unit.GetComponent<Unit>()));
        }
        
    }

}
