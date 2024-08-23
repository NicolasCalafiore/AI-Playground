using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unemployed : Job
{

    public Unemployed(GameObject Actor) : base(Actor)
    {
        Outfit = null;
        StartHour = 25;
        EndHour = -1;
        JobLocation = null;

    }


    public override void FindTask()
    {
    }

    public override void Update()
    {
        Debug.Log("Update() called on Unemployed");
    }


}