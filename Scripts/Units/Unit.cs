using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnitEnums;

public class Unit : MonoBehaviour
{

    public GameObject house;
    public NavMeshAgent agent;
    public Job job = null;
    [SerializeField] public int happiness = 50;
    [SerializeField] public int money = 0;
    [SerializeField] public int nourishment;
    [SerializeField] public int energy;
    [SerializeField] public int social;
    [SerializeField] public int noruishmentDX;
    [SerializeField] public int energyDX;
    [SerializeField] public int socialDX;
    [SerializeField] public string jobstr;
    public static int StatUpdateInterval = 3;
    public ActionManager actionManager;
    [SerializeField] private string state;
    [SerializeField] public bool Socializable;
    int baseSpeed = 5;

    public void SetJob(Job job){
        this.job = job;
    }

    void Start()
    {
        FindRequiredComponents();
        GenerateStats();
        actionManager.SetAction();
        StartCoroutine(CharacterStatsTick());
    }


    void Update()
    {
        if( job != null)
            jobstr = job.GetType().Name;
            
        if (job != null && job.startHour <= TimeManager.instance.hour && TimeManager.instance.hour <= job.endHour && actionManager.action.GetType().Name != "Working") {
            actionManager.SetAction();
        }
        
        agent.speed = baseSpeed * TimeManager.UniversalGameSpeed;
        actionManager.Update();

        state = actionManager.action.GetType().Name;
        Socializable = actionManager.action.socializable;

        if(actionManager.action.isDone)
            actionManager.SetAction();
        
    }

    void FindRequiredComponents(){
        house = UnitUtils.FindHouse();
        agent = GetComponent<NavMeshAgent>();
        actionManager = new ActionManager(this);
    
    }

    void GenerateStats(){
        nourishment = UnityEngine.Random.Range(0, 100);
        energy = UnityEngine.Random.Range(0, 100);
        social = UnityEngine.Random.Range(0, 100);

        noruishmentDX = UnityEngine.Random.Range(1, 3);
        energyDX = UnityEngine.Random.Range(1, 3);
        socialDX = UnityEngine.Random.Range(1, 3);

    }

    IEnumerator CharacterStatsTick(){
        while (true){
            yield return new WaitForSeconds(StatUpdateInterval);
            if(actionManager.action.GetType().Name != "Eat")
                nourishment -= noruishmentDX * (int) TimeManager.UniversalGameSpeed;
            if(actionManager.action.GetType().Name != "Sleep")
                energy -= energyDX * (int) TimeManager.UniversalGameSpeed;
            if(actionManager.action.GetType().Name != "Socialize")
                social -= socialDX * (int) TimeManager.UniversalGameSpeed;
        }
    }



    
}
