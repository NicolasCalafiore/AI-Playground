using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Center : Commercial
{
    public Center(){
        employeeCapacity = 10;
        occupantCapacity = 20;
        effectValue = 20;
    }

    public override void Awake(){
        WorldRegister.RegisterCenter(this);
    }






}
