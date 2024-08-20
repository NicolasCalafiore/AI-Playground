using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : Action
{
    private float timeSinceLastUpdate = 0f;
    private float updateInterval = 2f;
    private int interval = UnitUtils.GetRandomInt(5, 15);

    public Vector3 target;
    public override int Priority {get{return 1;}}
    public override int SatisfactionLevel {get{return 100;}}
    bool isAtResturant = false;
    bool isFull;
    int resturantRadius = 5;
    int fullTarget = 75;

    public Eat(Unit unit) : base(unit){
        isDone = false;
        target = UnitUtils.FindClosestTag(unit.gameObject, "Resturant").transform.Find("Door").transform.position;
        unit.transform.Find("Body").GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

    public override void Execute(){
            unit.GetComponent<Unit>().agent.SetDestination(target);
    }

    public override void Update()
    {
        isAtResturant = unit.GetComponent<Unit>().agent.remainingDistance <= resturantRadius;
        isFull = unit.GetComponent<Unit>().nourishment >= fullTarget;

        if (isAtResturant)
            AtResturant();

        if(isFull)
            Full();
        
        Tick();
    }

    public override void Tick(){
        timeSinceLastUpdate += Time.deltaTime;

        if(timeSinceLastUpdate >= updateInterval){

            if(isAtResturant)
                unit.GetComponent<Unit>().nourishment += interval;

            timeSinceLastUpdate = 0f;
        }
    }


    private void AtResturant(){
         unit.transform.Find("Body").gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void Full(){
         unit.transform.Find("Body").gameObject.GetComponent<MeshRenderer>().enabled = true;
        isDone = true;
    }


}
