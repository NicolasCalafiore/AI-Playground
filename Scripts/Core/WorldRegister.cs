using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldRegister
{

    public static List<House> Houses = new List<House>();
    public static List<Resturant> Resturants = new List<Resturant>();
    public static List<Center> Centers = new List<Center>();
    public static List<PoliceStation> PoliceStations = new List<PoliceStation>();

    public static void RegisterHouse(House house) => Houses.Add(house);
    public static void RegisterResturant(Resturant resturant) => Resturants.Add(resturant);
    public static void RegisterCenter(Center center) => Centers.Add(center);
    public static void RegisterPoliceStation(PoliceStation policeStation) => PoliceStations.Add(policeStation);

    public static House GetAvailableHouse()
    {
        foreach (House house in Houses)
            if (!house.IsFull())
                return house;
        
        return null;
    }

    public static PoliceStation GetUnderstaffedPoliceStation()
    {
        foreach (PoliceStation policeStation in PoliceStations)
            if (!policeStation.IsFull())
                return policeStation;
        
        return null;
    }

    


}
