using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Structure : MonoBehaviour{
    [SerializeField] int occupantCapacityDebug;
    [SerializeField] int occupancyDebug;
    protected List<Unit> occupants = new List<Unit>();
    protected int occupantCapacity;
    public Structure(){

    }

    public abstract void Awake();

    void Update(){
        occupantCapacityDebug = occupantCapacity;
        occupancyDebug = occupants.Count;
    }

    public bool IsFull(){
        Debug.Log("Occupants: " + occupants.Count + " Capacity: " + occupantCapacity);
        return occupants.Count >= occupantCapacity;
    }

    public void EnterStructure(Unit unit){
        occupants.Add(unit);
    }

    public void ExitStructure(Unit unit){
        occupants.Remove(unit);
    }

    public void AddOccupant(Unit unit){
        occupants.Add(unit);    
    }

    

}