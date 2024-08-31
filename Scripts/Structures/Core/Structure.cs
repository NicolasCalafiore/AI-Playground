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
    public abstract void UpdateOccupancy();

    void Update(){
        occupantCapacityDebug = occupantCapacity;
        occupancyDebug = occupants.Count;
    }

    public bool IsFull() => occupants.Count >= occupantCapacity;
    public void EnterStructure(Unit unit){
        occupants.Add(unit);
        UpdateOccupancy();
    }
    public void ExitStructure(Unit unit){
        occupants.Remove(unit);
        UpdateOccupancy();
    }
    public void AddOccupant(Unit unit){
        occupants.Add(unit);    
        UpdateOccupancy();
    }
    

    

}