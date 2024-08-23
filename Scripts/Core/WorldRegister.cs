using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldRegister
{
    private static List<GameObject> houses = new List<GameObject>();
    private static List<GameObject> resturants = new List<GameObject>();


    public static void RegisterStructure(GameObject structure)
    {
        Debug.Log("Registering Structure: " + structure.GetType());

        if (structure.GetComponent<House>() != null)
            houses.Add(structure.gameObject);

        if (structure.GetComponent<Resturant>() != null)
            resturants.Add(structure.gameObject);
        
    }

    public static List<GameObject> GetStructures()
    {
        return houses;
    }
}
