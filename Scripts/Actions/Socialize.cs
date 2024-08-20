using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class Socialize : Action
{
    public Vector3 target;
    private float timeSinceLastUpdate = 0f;
    private float updateInterval = 2f;
    private int socializeStrength = UnitUtils.GetRandomInt(10, 20);
    public override int Priority {get{return 1;}}
    public override int SatisfactionLevel {get{return UnityEngine.Random.Range(60, 100);}}
    public bool isAtCenter = false;
    public bool isSatisfied = false;
    public int socialize_radius = 15;

    public Socialize(Unit unit) : base(unit){
        isDone = false;
        target = UnitUtils.FindClosestTag(unit.gameObject, "Center").transform.position;
        unit.transform.Find("Body").GetComponent<MeshRenderer>().material.color = Color.white;
    }

    public override void Execute(){
            unit.GetComponent<Unit>().agent.SetDestination(target);
    }

    public override void Update()
    {
        isAtCenter = Vector3.Distance(unit.transform.position, target) <= socialize_radius;
        isSatisfied = unit.GetComponent<Unit>().social >= SatisfactionLevel;


        if (isAtCenter)
            AtCenter();

        if(isSatisfied)
            isDone = true;

        Tick();
        
    }

    public override void Tick(){
        timeSinceLastUpdate += Time.deltaTime;

        if (timeSinceLastUpdate >= updateInterval)
        {
            if(isAtCenter){
                unit.GetComponent<Unit>().social += socializeStrength;
                timeSinceLastUpdate = 0f;
            }
        }
        
    }
    
    private void AtCenter(){

    }


}
