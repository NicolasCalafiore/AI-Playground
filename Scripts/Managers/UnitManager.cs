using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{  
    [SerializeField] Vector2 size;
    [SerializeField] int maxUnits;
    List<GameObject> units = new List<GameObject>();
    [SerializeField] public int numberOfTeams;
    private Dictionary<int, Color> teamColors = new Dictionary<int, Color>();
    void Awake(){
        Debug.Log("UnitManager Awake");

        teamColors.Add(0, Color.red);
        teamColors.Add(1, Color.blue);
        teamColors.Add(2, Color.green);
        teamColors.Add(3, Color.yellow);
        teamColors.Add(4, Color.magenta);
        teamColors.Add(5, Color.cyan);
        teamColors.Add(6, Color.grey);
        teamColors.Add(7, Color.black);
        teamColors.Add(8, Color.white);
        
    }


    void Start(){
        Debug.Log("UnitManager Start");
        for(int i = 0; i < maxUnits; i++){
            GameObject prefab = Resources.Load<GameObject>("Prefabs/Unit");
            GameObject unit = Instantiate(prefab, new Vector3(UnityEngine.Random.Range(0, size.x), 0, UnityEngine.Random.Range(0, size.y)), Quaternion.identity);
            units.Add(unit);



            unit.GetComponent<AI>().team = UnityEngine.Random.Range(0, numberOfTeams);
            unit.GetComponent<AI>().teamColor = teamColors[unit.GetComponent<AI>().team];
        }
    }


    public void SpawnUnit(){
        GameObject prefab = Resources.Load<GameObject>("Prefabs/Unit");
        GameObject unit = Instantiate(prefab, new Vector3(UnityEngine.Random.Range(0, size.x), 0, UnityEngine.Random.Range(0, size.y)), Quaternion.identity);
        units.Add(unit);
    }   
}
