using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class Working : Action
{
    public Vector3 target;
    private float timeSinceLastUpdate = 0f;
    private float updateInterval = 2f;
    private int socializeStrength = UnitUtils.GetRandomInt(10, 20);
    public override int Priority {get{return 1;}}
    public override int SatisfactionLevel {get{return UnityEngine.Random.Range(60, 100);}}
    public bool isAtJobLocation = false;
    public int enter_radius = 3;
    public bool working = false;

        public Working(Unit unit) : base(unit){
        unit.transform.Find("Body").gameObject.GetComponent<MeshRenderer>().enabled = true;
        isDone = false;
        target = unit.job.jobLocation.transform.Find("Door").transform.position;
        
        unit.gameObject.transform.Find(unit.job.outfit).gameObject.SetActive(true);
    }

    public override void Execute(){
            unit.GetComponent<Unit>().agent.SetDestination(target);
    }

    public override void Update()
    {
        isAtJobLocation = Vector3.Distance(unit.transform.position, target) <= enter_radius;


        if (isAtJobLocation)
            AtJob();
            
        if(working)
            WorkCycle();

         if(TimeManager.instance.hour >= unit.GetComponent<Unit>().job.endHour){
            unit.gameObject.transform.Find(unit.job.outfit).gameObject.SetActive(false);
            isDone = true;
         }

        Tick();
        
    }

    public override void Tick(){
        timeSinceLastUpdate += Time.deltaTime;

        if (timeSinceLastUpdate >= updateInterval)
        {

        }
        
    }

    public void AtJob(){
        working = true;
    }

    public void WorkCycle(){
        unit.GetComponent<Unit>().job.Update(unit);

        if(unit.GetComponent<Unit>().job.taskDone == true)
            unit.GetComponent<Unit>().job.FindTask(unit);
    }
    


}
