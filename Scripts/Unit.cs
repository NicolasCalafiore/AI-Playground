using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    public string nourishment_str;
    public string energy_str;
    public string social_str;
    public GameObject bed;
    public NavMeshAgent agent;
    public Stat<int, float> nourishment { get; set; }
    public Stat<int, float> energy { get; set; }
    public Stat<int, float> social { get; set; }
    public static int StatUpdateInterval = 3;
    public ActionManager actionManager;

    void Start()
    {
        bed = UnitUtils.FindBed();
        agent = GetComponent<NavMeshAgent>();
        nourishment = new Stat<int, float>(UnitUtils.GetRandomInt(25, 85), UnitUtils.GetRandomFloat(.25f, 2f));
        energy = new Stat<int, float>(UnitUtils.GetRandomInt(10, 40), UnitUtils.GetRandomFloat(.25f, 2f));
        social = new Stat<int, float>(UnitUtils.GetRandomInt(25, 85), UnitUtils.GetRandomFloat(.25f, 2f));
        StartCoroutine(CharacterStatsTick());
        actionManager = new ActionManager(this);
        actionManager.SetAction();

    }


    void Update()
    {
        nourishment_str = "Nourishment: " + nourishment.Value;
        energy_str = "Energy: " + energy.Value;
        social_str = "Social: " + social.Value;

        actionManager.action.Update();

        if(actionManager.action.isDone) 
        {
            Debug.Log("Action completed, setting new action.");
            actionManager.isDone = true;
        }


        // Set a new action if the current one is done
        if(actionManager.isDone){
            actionManager.SetAction();
        }
    }


    IEnumerator CharacterStatsTick(){
        while (true){
            yield return new WaitForSeconds(StatUpdateInterval);
            nourishment.Value = nourishment.Value - 1;
            energy.Value -= 1;
            social.Value -= 1;
        }
    }



    
}
