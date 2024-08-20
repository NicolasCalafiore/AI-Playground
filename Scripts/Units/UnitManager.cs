using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnitEnums;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private int unitCount;
    [SerializeField] private int policeCount;
    [SerializeField] private int cookCount;
    [SerializeField] private Vector2 spawnRange;
    public static UnitManager instance;
    public List<Unit> units = new List<Unit>();

    void Start()
    {
        instance = this;
        SpawnUnits();
    }

    void Update()
    {
        
    }

    void SpawnUnits()
    {

        for (int i = 0; i < unitCount; i++)
        {
            Vector3 spawnPosition = GetValidSpawnPosition();
            GameObject unitObject = Instantiate(IOManager.GetUnitPrefab(), spawnPosition, Quaternion.identity);
            Unit unit = unitObject.GetComponent<Unit>();
            unit.SetJob(new None());
            units.Add(unit);
        }

        for (int i = 0; i < policeCount; i++)
        {
            Vector3 spawnPosition = GetValidSpawnPosition();
            GameObject unitObject = Instantiate(IOManager.GetUnitPrefab(), spawnPosition, Quaternion.identity);
            Unit unit = unitObject.GetComponent<Unit>();
            unit.SetJob(new Police());
            units.Add(unit);
        }

        for (int i = 0; i < cookCount; i++)
        {
            Vector3 spawnPosition = GetValidSpawnPosition();
            GameObject unitObject = Instantiate(IOManager.GetUnitPrefab(), spawnPosition, Quaternion.identity);
            Unit unit = unitObject.GetComponent<Unit>();
            unit.SetJob(new Cook());
            units.Add(unit);
        }



    }

    Vector3 GetValidSpawnPosition()
    {
        Vector3 spawnPosition;
        bool positionIsValid = false;

        do
        {
            spawnPosition = new Vector3(Random.Range(0, spawnRange.x), 0, Random.Range(0, spawnRange.y));
            Collider[] colliders = Physics.OverlapSphere(spawnPosition, 1f); // Adjust the radius as needed

            if (colliders.Length == 1)
            {
                positionIsValid = true;
            }
        } while (!positionIsValid);

        return spawnPosition;
    }
}
