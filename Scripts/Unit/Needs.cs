using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Needs : MonoBehaviour
{

    float UpdateInterval = 1f;
    float TimeSinceLastUpdate = 0f;
    [SerializeField] private int Hunger = 0;
    [SerializeField] private int Sleep = 0;
    [SerializeField] private int Social = 0;
    [SerializeField] private int HungerThreshold = 2;
    [SerializeField] private int SleepThreshold = 2;
    
    void Update(){

        TimeSinceLastUpdate += Time.deltaTime;
        if (TimeSinceLastUpdate >= UpdateInterval)
        {
            TimeSinceLastUpdate = 0f;
            Hunger++;
            Sleep++;
            Social++;
        }
    }

    public bool IsHungry(){
        return Hunger > 15;
    }

    public bool IsSleepy(){
        return Sleep > 5;
    }

    public void Eat(){
        Debug.Log("Ate");
        Hunger -= GetComponent<Unit>().structure.GetComponent<Resturant>().effectValue;
    }

    public void GoToSleep(){
        Debug.Log("Slept");
        Sleep -= GetComponent<Unit>().home.sleepValue;
    }

    public bool HungerIsSatsified(){
        return Hunger < HungerThreshold;
    }

    public bool IsFullyRested(){
        return Sleep < SleepThreshold;
    }





}
