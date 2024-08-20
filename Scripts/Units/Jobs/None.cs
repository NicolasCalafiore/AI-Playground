using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class None : Job
{
    
    public None() : base()
    {
        pay = 2;
        outfit = "None";

        startHour = 25;
        endHour = -1;
    }

    
    public override void FindTask(Unit unit)
    {

    }

    public override void Update(Unit unit)
    {

    }

}
