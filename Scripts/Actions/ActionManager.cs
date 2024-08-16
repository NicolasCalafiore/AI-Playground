using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager
{
    public Unit unit;
    public Action action;
    public bool isDone = false;
    public ActionManager(Unit unit){
        this.unit = unit;
    }

    public void SetAction(){
        isDone = false;
        Debug.Log(unit.GetComponent<Unit>().energy.Value);
        if(unit.GetComponent<Unit>().energy.Value < 20){
            Debug.Log("Action Set: Sleep");
            action = new Sleep(unit);
            action.Execute();
        }
        else if(unit.GetComponent<Unit>().nourishment.Value < 50){
            Debug.Log("Action Set: Eat");
            action = new Eat(unit);
            action.Execute();
        }
        else{   
            Debug.Log("Action Set: Idle");
            action = new Idle(unit);
            action.Execute();
        }
    }




}
