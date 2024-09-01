using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static JobEnums;

public class Working: Activity{

    public Stage stage;
    float UpdateInterval = 1f;
    float TimeSinceLastUpdate = 0f;
    public Working(Unit unit): base(unit){
        
    }
    public override void Start(){

        unit.MoveToStructure(unit.GetComponent<Job>().job.Location.GetComponent<Structure>());
        stage = Stage.GoingToWork;

        unit.SetOutfit(unit.GetComponent<Job>().job.uniform);
        unit.ShowOutfit();
    }
    public override void Update(){

        TimeSinceLastUpdate += Time.deltaTime;
        
        if(Vector3.Distance(unit.gameObject.transform.position, unit.targetPosition) < 5 && stage == Stage.GoingToWork){
            stage = Stage.Working;
            if(unit.GetComponent<Job>().job.isInside) 
                unit.EnterStructure(unit.GetComponent<Job>().job.Location.GetComponent<Structure>());
        }

        if(TimeSinceLastUpdate >= UpdateInterval && stage == Stage.Working){
            TimeSinceLastUpdate = 0f;
            unit.GetComponent<Job>().WorkUpdate();
        }

        if(!unit.GetComponent<Job>().job.IsWorkingHours())
            End();
        
    }
    public override void End(){
        
        IsFinished = true;
        unit.GetComponent<Needs>().social.isActive = true;
        if(unit.GetComponent<Job>().job.isInside) 
            unit.ExitStructure();

        unit.RemoveOutfit();

    }
}