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
    private int SleepThreshold = 10;
    private int HungerThreshold = 20;

    public ActivityManager(Unit unit)
    {
        this.Unit = unit;
        TickManager.Ticked += TickCycle; // Corrected: Do not invoke the method, just pass it as a delegate
    }

    public void SetActivity(){
        if(Unit.needs.Sleep > SleepThreshold){
            CurrentActivity = new Sleep(Unit);
            CurrentActivity.Execute();
            return;
        }

        if(Unit.needs.Hunger > HungerThreshold){
            CurrentActivity = new Eat(Unit);
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
        Debug.Log("Tick Cycle");
    }

    public int GetSleepThreshold(){
        return SleepThreshold;
    }

    public int GetHungerThreshold(){
        return HungerThreshold;
    }
}
