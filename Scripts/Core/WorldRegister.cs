using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldRegister
{

    public static List<House> Houses = new List<House>();
    public static List<Resturant> Resturants = new List<Resturant>();
    public static void RegisterHouse(House house)
    {
        Debug.Log("Registering house");
        Houses.Add(house);
    }

    public static void RegisterResturant(Resturant resturant)
    {
        Debug.Log("Registering resturant");
        Resturants.Add(resturant);
    }

    public static House GetAvailableHouse()
    {
        foreach (House house in Houses)
        {
            if (!house.IsFull())
            {
                return house;
            }
        }
        return null;
    }

    


}
