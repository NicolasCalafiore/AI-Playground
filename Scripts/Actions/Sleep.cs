using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class Sleep : Action
{
    public Vector3 target;
    private float timeSinceLastUpdate = 0f;
    private float updateInterval = 2f;
    private int sleepStrength = UnitUtils.GetRandomInt(5, 15);
    public override int Priority {get{return 1;}}
    public override int SatisfactionLevel {get{return 75;}}
    public bool isAtHouse = false;
    public int house_radius = 2;

    public Sleep(Unit unit) : base(unit){
        isDone = false;
        target = unit.house.transform.Find("Structure").transform.Find("Door").transform.position;
        unit.transform.Find("Body").GetComponent<MeshRenderer>().material.color = Color.black;
    }

    public override void Execute(){
            unit.GetComponent<Unit>().agent.SetDestination(target);
    }

    public override void Update()
    {
        isAtHouse = Vector3.Distance(unit.transform.position, target) <= house_radius;

        if (isAtHouse)
            AtHouse();
        
        if(unit.GetComponent<Unit>().energy >= 100)
            WakingUp();

        Tick();
        
    }

    public override void Tick(){
        timeSinceLastUpdate += Time.deltaTime;

        if (timeSinceLastUpdate >= updateInterval)
        {
            if(isAtHouse){
                unit.GetComponent<Unit>().energy += sleepStrength;
                timeSinceLastUpdate = 0f;
            }
        }
        
    }
    
    private void AtHouse(){
        unit.GetComponent<Unit>().house.transform.Find("Sleeping").gameObject.SetActive(true);
        unit.transform.Find("Body").gameObject.GetComponent<MeshRenderer>().enabled = false;

    }
    private void WakingUp(){
            unit.GetComponent<Unit>().house.transform.Find("Sleeping").gameObject.SetActive(false);
            unit.transform.Find("Body").gameObject.GetComponent<MeshRenderer>().enabled = true;
            isDone = true;
    }


}
