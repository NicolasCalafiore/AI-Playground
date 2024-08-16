using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private int unitCount;
    [SerializeField] private Vector2 spawnRange;
    public static UnitManager instance;
    public List<Unit> units = new List<Unit>();
    void Start()
    {
        instance = this;
        for (int i = 0; i < unitCount; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(0, spawnRange.x), 0, Random.Range(0, spawnRange.y));
            GameObject unitObject = Instantiate(IOManager.GetUnitPrefab(), spawnPosition, Quaternion.identity);
            Unit unit = unitObject.GetComponent<Unit>();
            units.Add(unit);
        }
    }

    
    void Update()
    {
        
    }
}
