using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : Job
{
 

    public Police() : base()
    {
        List<GameObject> policeStations = new List<GameObject>();
        policeStations.AddRange(GameObject.FindGameObjectsWithTag("Police"));
        this.jobLocation = policeStations[0];
        target = jobLocation.transform.position;
        outfit = "Police";

        pay = 10;
        startHour = 0;
        endHour = 24;
    }

    public override void FindTask(Unit unit)
    {
        target = UnitUtils.GetRandomLocationInRadius(unit.transform.position, 20);
        unit.GetComponent<Unit>().agent.SetDestination(target);
        taskDone = false;
    }

    public override void Update(Unit unit)
    {
        if(Vector3.Distance(unit.transform.position, target) <= 5){
            taskDone = true;
        }
    }


    


}
