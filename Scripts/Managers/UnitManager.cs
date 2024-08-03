using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager instance;
    public static event Action OnSetStance;

    public void Awake(){
        instance = this;
         
    }

    public void SpawnUnit(){
        GameObject unit = Resources.Load<GameObject>("Prefabs/Unit");
        Instantiate(unit);
        unit.GetComponent<Unit>().power = UnityEngine.Random.Range(1, 25);
        unit.GetComponent<Unit>().health = UnityEngine.Random.Range(50, 100);
        unit.GetComponent<Unit>().attackSpeed = UnityEngine.Random.Range(1, 10);
        float randomX = UnityEngine.Random.Range(0, 1000);
        float randomZ = UnityEngine.Random.Range(0, 1000);
        unit.transform.position = new Vector3(randomX, 0, randomZ);
    
    }   
    public void SetStance(){
        OnSetStance?.Invoke();
    }

}
