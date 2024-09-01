using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Resturant : Commercial
{

    public override void Awake(){
        
        employeeCapacity = 10;
        occupantCapacity = 20;
        effectValue = 15;

        WorldRegister.RegisterResturant(this);
    }


    public override void UpdateOccupancy()
    {

    }





}
