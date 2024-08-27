using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Resturant : Commercial
{
    public Resturant(){
        employeeCapacity = 10;
        occupantCapacity = 20;
        effectValue = 5;
    }

    public override void Awake(){
        WorldRegister.RegisterResturant(this);
    }






}
