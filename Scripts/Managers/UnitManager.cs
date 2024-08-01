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

        GameObject terrain = GameObject.Find("Terrain");
        
        float randomX = UnityEngine.Random.Range(0, 1000);
        float randomZ = UnityEngine.Random.Range(0, 1000);
        unit.transform.position = new Vector3(randomX, 0, randomZ);
    
    }   
    public void SetStance(){
        OnSetStance?.Invoke();
    }

}
