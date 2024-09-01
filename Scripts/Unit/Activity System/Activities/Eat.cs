using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Eat: Activity{

    float UpdateInterval = 2f;
    float TimeSinceLastUpdate = 0f;
    bool IsAtResturant;
    
    public Eat(Unit unit): base(unit){  }
    
    public override void Start(){
        unit.MoveToStructure(UnitUtils.FindClosestTag(unit, "Resturant").GetComponent<Structure>());
        IsAtResturant = false;
    }
    public override void Update(){

        TimeSinceLastUpdate += Time.deltaTime;
        float distanceToTarget = Vector3.Distance(unit.gameObject.transform.position, unit.targetPosition);

        if(distanceToTarget < 3 && !IsAtResturant){
            unit.EnterStructure(GameObject.Find("Resturant").GetComponent<Structure>());
            IsAtResturant = true;
            unit.GetComponent<Needs>().hunger.isActive = false;
        }

        if(TimeSinceLastUpdate >= UpdateInterval && IsAtResturant){
            TimeSinceLastUpdate = 0f;
            unit.GetComponent<Needs>().Eat();
        }

        if(unit.GetComponent<Needs>().HungerIsSatsified())
            End();
        
    }

    public override void End(){

        unit.GetComponent<Needs>().hunger.isActive = true;
        unit.ExitStructure();
        IsFinished = true;
    }
}