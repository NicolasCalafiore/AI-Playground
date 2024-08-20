using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook : Job
{
 

    public Cook() : base()
    {
        List<GameObject> policeStations = new List<GameObject>();
        policeStations.AddRange(GameObject.FindGameObjectsWithTag("Resturant"));
        this.jobLocation = policeStations[0];
        target = jobLocation.transform.position;
        outfit = "Cook";

        pay = 6;
        startHour = 3;
        endHour = 6;
    }

    public override void FindTask(Unit unit)
    {
      
    }

    public override void Update(Unit unit)
    {

    }


    


}
