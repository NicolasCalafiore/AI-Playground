using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Needs
{
    public int Sleep = 0;
    public int Hunger = 0;
    public int Social = 0;
    TickManager _TickManager = new TickManager(1);
    public bool EnableSleepEffect = true;
    public bool EnableHungerEffect = true;
    public bool EnableSocialEffect = true;
    private int SleepDX;
    private int HungerDX;
    private int SocialDX;
    public int SleepThreshold { get; private set; }
    public int HungerThreshold { get; private set; }
    public int SocialThreshold { get; private set; }



    public Needs(){
        _TickManager.Ticked += TickCycle;
         
        SleepDX = Random.Range(1, 3);
        HungerDX = Random.Range(1, 3);
        SocialDX = Random.Range(1, 3);
        SleepThreshold = Random.Range(50, 100);
        HungerThreshold = Random.Range(35, 100);
        SocialThreshold = Random.Range(20, 100);
    }

    public void UpdateNeeds(){
        if(EnableSleepEffect)
            Sleep+=SleepDX;

        if(EnableHungerEffect)
            Hunger+=HungerDX;

        if(EnableSocialEffect)
            Social+=SocialDX;
    }

    public void Update(){
        _TickManager.Tick();
    }
    public void TickCycle(){
        UpdateNeeds();
    }




}
