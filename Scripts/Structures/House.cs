using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class House : Residential
{
    public House(){
        occupantCapacity = 4;
        visitorCapacity = 5;
        sleepValue = 5;
    }

    public override void Awake(){
        WorldRegister.RegisterHouse(this);
    }
    







}
