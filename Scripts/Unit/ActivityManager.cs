using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ActivityManager : MonoBehaviour
{
    
    Activity currentActivity;
    [SerializeField] private string DebugActivity;
    void Awake(){
      
    }

    void Start()
    {
        if(GetComponent<Job>().job != null && GetComponent<Job>().job.IsWorkingHours())
            currentActivity = new Working(gameObject.GetComponent<Unit>());
        else if(gameObject.GetComponent<Needs>().IsHungry())
            currentActivity = new Eat(gameObject.GetComponent<Unit>());
        else if(gameObject.GetComponent<Needs>().IsSleepy())
            currentActivity = new Sleep(gameObject.GetComponent<Unit>());
        else if(gameObject.GetComponent<Needs>().IsSocial())
            currentActivity = new Socialize(gameObject.GetComponent<Unit>());
        else
            currentActivity = new Idle(gameObject.GetComponent<Unit>());
            
        currentActivity.Start();
    }


    // Update is called once per frame
    void Update()
    {        if(currentActivity.IsFinished)
            Start();
        
        currentActivity.Update();
        DebugActivity = currentActivity.GetType().Name;
      
    }

    
}
