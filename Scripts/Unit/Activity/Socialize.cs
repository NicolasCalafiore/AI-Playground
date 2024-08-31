using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Socialize: Activity{

    private bool isSocializing = false;
    GameObject center;
    float UpdateInterval = 1f;
    float TimeSinceLastUpdate = 0f;
    public Socialize(Unit unit): base(unit){
        
    }
    public override void Start(){
        TargetVector = UnitUtils.FindClosestTag(unit, "Center").transform.position;
        center = UnitUtils.FindClosestTag(unit, "Center");

        unit.GetComponent<NavMeshAgent>().SetDestination(TargetVector);
    }
    public override void Update(){
        TimeSinceLastUpdate += Time.deltaTime;
        
        if(Vector3.Distance(unit.gameObject.transform.position, TargetVector) < 5 && !isSocializing){
            isSocializing = true;
            unit.EnterStructure(center.GetComponent<Structure>());
            unit.Show();
        }

        if(TimeSinceLastUpdate >= UpdateInterval && isSocializing){
            Debug.Log("Socializing Update");
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
    }
}