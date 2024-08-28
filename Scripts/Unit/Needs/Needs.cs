using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Needs : MonoBehaviour
{

    float UpdateInterval = 2f;
    float TimeSinceLastUpdate = 0f;
    public Hunger hunger;
    public Energy energy;
    [SerializeField] private int hungerValue;
    [SerializeField] private int hungerRate;
    [SerializeField] private int hungerThreshold;
    [SerializeField] private int hungerSatisfied;
    
    [SerializeField] private int energyValue;
    [SerializeField] private int energyRate;
    [SerializeField] private int energyThreshold;
    [SerializeField] private int energySatisfied;
    [SerializeField] private bool HungerisActive;
    [SerializeField] private bool EnergyisActive;


    void Awake(){
        //int value, int rate, int threshold, int satisfied) : base(value, rate, threshold, satisfied
        int HungerRate = Random.Range(1, 7);
        int SleepRate = Random.Range(1, 7);

        int HungerThreshold = Random.Range(40, 80);
        int SleepThreshold = Random.Range(70, 100);

        int HungerSatisfied = Random.Range(0, 20);
        int SleepSatisfied = Random.Range(0, 20);

        hunger = new Hunger(0, HungerRate, HungerThreshold, HungerSatisfied);
        energy = new Energy(0, SleepRate, SleepThreshold, SleepSatisfied);
    }
    
    void Update(){

        TimeSinceLastUpdate += Time.deltaTime;
        if (TimeSinceLastUpdate >= UpdateInterval)
        {
            hunger.Increment();
            energy.Increment();
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
    }

    public bool IsHungry(){
        return hunger.IsNeeded();
    }

    public bool IsSleepy(){
        return energy.IsNeeded();
    }

    public void Eat(){
        hunger.Decrement(GetComponent<Unit>().structure.GetComponent<Resturant>().effectValue);
    }

    public void GoToSleep(){
        energy.Decrement(GetComponent<Unit>().home.sleepValue);
    }

    public bool HungerIsSatsified(){
        return hunger.IsSatisfied(hunger.value);
    }

    public bool IsFullyRested(){
        return energy.IsSatisfied(energy.value);
    }





}
