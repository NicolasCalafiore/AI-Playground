using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Residential : Structure{

    protected int visitorCapacity;
    protected List<Unit> visitors = new List<Unit>();
    public int sleepValue;
    public Residential(){

    }

    public bool IsResidentFull() => occupants.Count >= occupantCapacity;
    public bool IsVisitorsFull() => visitors.Count >= visitorCapacity;
    
    public void EnterResidence(Unit unit) => occupants.Add(unit);
    public void ExitResidence(Unit unit) => occupants.Remove(unit);

    public void VisitResidence(Unit unit) => visitors.Add(unit);
    public void LeaveVisitResidence(Unit unit) => visitors.Remove(unit);
    


}