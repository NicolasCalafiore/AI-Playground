using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PoliceStation : Commercial
{

    public override void Awake(){

        employeeCapacity = 10;
        occupantCapacity = 20;
        effectValue = 20;

        WorldRegister.RegisterPoliceStation(this);
    }
    

    public override void UpdateOccupancy()
    {

    }




}
