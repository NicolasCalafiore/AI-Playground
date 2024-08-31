using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PoliceStation : Commercial
{
    public PoliceStation(){
        employeeCapacity = 10;
        occupantCapacity = 20;
        effectValue = 20;
    }

    public override void Awake() => WorldRegister.RegisterPoliceStation(this);
    






}
