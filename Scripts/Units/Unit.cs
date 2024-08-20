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
    public Job job = Job.None;
    [SerializeField] public int happiness = 50;
    [SerializeField] public int money = 0;
    [SerializeField] public int nourishment;
    [SerializeField] public int energy;
    [SerializeField] public int social;
    [SerializeField] public int noruishmentDX;
    [SerializeField] public int energyDX;
    [SerializeField] public int socialDX;
    public static int StatUpdateInterval = 3;
    public ActionManager actionManager;
    [SerializeField] private string state;
    [SerializeField] public bool Socializable;

    public void SetJob(Job job){
        this.job = job;

        if(job == Job.Police){
            gameObject.transform.Find("PoliceOutfit").gameObject.SetActive(true);
        }
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
        nourishment = UnityEngine.Random.Range(50, 100);
        energy = UnityEngine.Random.Range(50, 100);
        social = UnityEngine.Random.Range(50, 100);

        noruishmentDX = UnityEngine.Random.Range(1, 5);
        energyDX = UnityEngine.Random.Range(1, 5);
        socialDX = UnityEngine.Random.Range(1, 5);

    }

    IEnumerator CharacterStatsTick(){
        while (true){
            yield return new WaitForSeconds(StatUpdateInterval);
            if(actionManager.action.GetType().Name != "Eat")
            nourishment -= noruishmentDX;
            if(actionManager.action.GetType().Name != "Sleep")
                energy -= energyDX;
            if(actionManager.action.GetType().Name != "Socialize")
                social -= socialDX;
        }
    }



    
}
