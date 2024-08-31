using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static JobEnums;

public class Job : MonoBehaviour{
    public JobBase job = null;
    public string JobName;

    public void SetJob(JobBase job){
        this.job = job;
    }

    void Update(){
        if(job == null) return;
        JobName = job.GetType().Name;
    }

    public void WorkUpdate(){
        job.Update();
    }







}