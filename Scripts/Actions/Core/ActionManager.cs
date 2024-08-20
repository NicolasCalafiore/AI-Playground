using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;

public class ActionManager
{
    public Unit unit;
    public Action action;
    private float timeSinceLastUpdate = 0f;
    private float updateInterval = 2f;
    private int energy_threshold = UnityEngine.Random.Range(15, 30);
    private int nourishment_threshold = UnityEngine.Random.Range(20, 50);
    private int social_threshold = UnityEngine.Random.Range(5, 60);

    public ActionManager(Unit unit){
        this.unit = unit;
    }

    public void SetAction(){

        if(unit.job != null && unit.GetComponent<Unit>().job.startHour <= TimeManager.instance.hour && TimeManager.instance.hour <= unit.GetComponent<Unit>().job.endHour){
            action = new Working(unit);
            action.Execute();
            return;
        }

        if(unit.GetComponent<Unit>().energy < energy_threshold)
            action = new Sleep(unit);
        
        else if(unit.GetComponent<Unit>().nourishment < nourishment_threshold)
            action = new Eat(unit);
        
        else  
            action = new Idle(unit);

            
        

        action.Execute();
    }

    public void Update(){
        action.Update();
        Tick();
    }

    private void Tick(){
        timeSinceLastUpdate += Time.deltaTime;
        if (timeSinceLastUpdate >= updateInterval)
        {
            if(action.GetType().Name == "Idle" && unit.social < social_threshold){
                action = new Socialize(unit);
                action.Execute();
            }
        }
    }

    internal void SetAction(Action action)
    {
        this.action = action;
        action.Execute();
    }
}
