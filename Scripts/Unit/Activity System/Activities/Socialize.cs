using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Socialize: Activity{

    private bool isSocializing = false;
    float UpdateInterval = 2f;
    float TimeSinceLastUpdate = 0f;
    public Socialize(Unit unit): base(unit){
        
    }
    public override void Start(){
        unit.MoveToStructure(UnitUtils.FindClosestTag(unit, "Center").GetComponent<Structure>());
    }
    public override void Update(){

        TimeSinceLastUpdate += Time.deltaTime;
        
        if(Vector3.Distance(unit.gameObject.transform.position, unit.targetPosition) < 5 && !isSocializing){
            isSocializing = true;
            unit.EnterStructure(unit.targetStructure);
        }

        if(TimeSinceLastUpdate >= UpdateInterval && isSocializing){
            TimeSinceLastUpdate = 0f;
            unit.GetComponent<Needs>().Socialize();
            unit.GetComponent<Needs>().social.isActive = false;
        }

        if(unit.GetComponent<Needs>().IsSocialized()){
            End();
        }

    }
    public override void End(){

        IsFinished = true;
        unit.GetComponent<Needs>().social.isActive = true;
        unit.ExitStructure();
    }
}