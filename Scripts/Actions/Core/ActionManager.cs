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

    public ActionManager(Unit unit){
        this.unit = unit;
    }

    public void SetAction(){

        if(unit.GetComponent<Unit>().energy < 20)
            action = new Sleep(unit);
        
        else if(unit.GetComponent<Unit>().nourishment < 50)
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
            if(action.GetType().Name == "Idle" && unit.social < 25){
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
