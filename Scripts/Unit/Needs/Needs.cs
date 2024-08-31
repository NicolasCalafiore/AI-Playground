using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Needs : MonoBehaviour
{

    float UpdateInterval = 2f;
    float TimeSinceLastUpdate = 0f;
    public Need hunger;
    public Need energy;
    public Need social;
    [SerializeField] private int hungerValue;
    [SerializeField] private int hungerRate;
    [SerializeField] private int hungerThreshold;
    [SerializeField] private int hungerSatisfied;
    [SerializeField] private bool HungerisActive;
    
    [SerializeField] private int energyValue;
    [SerializeField] private int energyRate;
    [SerializeField] private int energyThreshold;
    [SerializeField] private int energySatisfied;
    [SerializeField] private bool EnergyisActive;

    [SerializeField] private int socialValue;
    [SerializeField] private int socialRate;
    [SerializeField] private int socialThreshold;
    [SerializeField] private int socialSatisfied;
    [SerializeField] private bool SocialisActive;



    void Awake(){
        //int value, int rate, int threshold, int satisfied) : base(value, rate, threshold, satisfied
        int HungerRate = Random.Range(1, 7);
        int HungerSatisfied = Random.Range(0, 20);
        int HungerThreshold = Random.Range(40, 80);

        int SleepThreshold = Random.Range(70, 100);
        int SleepRate = Random.Range(1, 7);
        int SleepSatisfied = Random.Range(0, 20);

        int SocialRate = Random.Range(1, 7);
        int SocialSatisfied = Random.Range(0, 20);
        int SocialThreshold = Random.Range(40, 80);



        hunger = new Need(0, HungerRate, HungerThreshold, HungerSatisfied);
        energy = new Need(0, SleepRate, SleepThreshold, SleepSatisfied);
        social = new Need(0, SocialRate, SocialThreshold, SocialSatisfied);
    }
    
    void Update(){

        TimeSinceLastUpdate += Time.deltaTime;
        if (TimeSinceLastUpdate >= UpdateInterval)
        {
            hunger.Increment();
            energy.Increment();
            social.Increment();
            TimeSinceLastUpdate = 0f;
            UpdateSerializeFields();
        }

        HungerisActive = hunger.isActive;
        EnergyisActive = energy.isActive;

    }

    public void UpdateSerializeFields(){
            hungerValue = hunger.value;
            energyValue = energy.value;
            hungerRate = hunger.rate;
            energyRate = energy.rate;
            hungerThreshold = hunger.threshold;
            energyThreshold = energy.threshold;
            hungerSatisfied = hunger.satisfied;
            energySatisfied = energy.satisfied;
            socialValue = social.value;
            socialRate = social.rate;
            socialThreshold = social.threshold;
            socialSatisfied = social.satisfied;
            SocialisActive = social.isActive;
    }

    public bool IsHungry() => hunger.IsNeeded();
    public bool IsSleepy() => energy.IsNeeded();
    public bool IsSocial() => social.IsNeeded();
    public void Eat() => hunger.Decrement(GetComponent<Unit>().targetStructure.GetComponent<Resturant>().effectValue);
    public void GoToSleep() => energy.Decrement(GetComponent<Unit>().home.sleepValue);
    public void Socialize(){
        Debug.Log("Decrement by " + GetComponent<Unit>().targetStructure.GetComponent<Center>().effectValue);
        social.Decrement(GetComponent<Unit>().targetStructure.GetComponent<Center>().effectValue);
    }
    public bool HungerIsSatsified() => hunger.IsSatisfied(hunger.value);
    public bool IsFullyRested() => energy.IsSatisfied(energy.value);
    public bool IsSocialized() => social.IsSatisfied(social.value);
    





}
