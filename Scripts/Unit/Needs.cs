using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Needs
{
    public int Sleep = 0;
    public int Hunger = 0;
    TickManager _TickManager = new TickManager(1);
    public bool EnableSleepEffect = true;
    public bool EnableHungerEffect = true;


    public Needs(){
         _TickManager.Ticked += TickCycle;
    }

    public void UpdateNeeds(){
        if(EnableSleepEffect)
            Sleep++;

        if(EnableHungerEffect)
            Hunger++;
    }

    public void Update(){
        _TickManager.Tick();
    }
    public void TickCycle(){
        UpdateNeeds();
    }




}
