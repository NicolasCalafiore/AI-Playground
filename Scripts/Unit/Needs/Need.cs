using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Need{
    public int value;
    public int rate;
    public int threshold;
    public int satisfied;
    public bool isActive = true;
    public Need(int value, int rate, int threshold, int satisfied){
        this.value = value;
        this.rate = rate;
        this.threshold = threshold;
        this.satisfied = satisfied;
    }

    public bool IsNeeded(){
        return value > threshold;
    }
    
    public bool IsSatisfied(int value){
        return value < satisfied;
    }   

    public void Increment(){
        if(isActive)
            this.value += rate;
    }

    public void Decrement(int value){
        this.value -= value;
    }
}