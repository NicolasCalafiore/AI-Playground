using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;

public class ActivityManager
{
    private TickManager TickManager = new TickManager(1);
    public Activity CurrentActivity;
    public Unit Unit;



    public ActivityManager(Unit unit)
    {

        this.Unit = unit;
        TickManager.Ticked += TickCycle; // Corrected: Do not invoke the method, just pass it as a delegate
    }

    public void SetActivity(){
//        Debug.Log(TimeManager.instance.hour);
        if(Unit.job is not Unemployed && TimeManager.instance.hour >= Unit.job.StartHour && TimeManager.instance.hour < Unit.job.EndHour){
            
            CurrentActivity = new Working(Unit);
            CurrentActivity.Execute();
            return;
        }
        if(Unit.needs.Sleep > Unit.needs.SleepThreshold){
            CurrentActivity = new Sleep(Unit);
            CurrentActivity.Execute();
            return;
        }

        if(Unit.needs.Hunger > Unit.needs.HungerThreshold){
            CurrentActivity = new Eat(Unit);
            CurrentActivity.Execute();
            return;
        }

        if(Unit.needs.Social > Unit.needs.SocialThreshold){
            CurrentActivity = new Socialize(Unit);
            CurrentActivity.Execute();
            return;
        }

        CurrentActivity = new Idle(Unit);

        CurrentActivity.Execute();
    }

    public void Update()
    {
        TickManager.Tick();
        CurrentActivity.Update();

        if(CurrentActivity.IsDone)
            SetActivity();
        
    }

    public void TickCycle()
    {
    }
}
