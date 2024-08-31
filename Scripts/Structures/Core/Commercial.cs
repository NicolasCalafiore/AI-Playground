using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Commercial : Structure{

    protected int employeeCapacity;
    protected List<Unit> employees = new List<Unit>();
    public int effectValue;

    public Commercial(){
        
    }

    public bool IsEmployeeFull() => employees.Count >= employeeCapacity;
    public bool IsCustomerFull() =>  occupants.Count >= occupantCapacity;

    public void EnterStaff(Unit unit) => employees.Add(unit);
    public void ExistStaff(Unit unit) => employees.Remove(unit);
    
    public void EnterCustomer(Unit unit) => occupants.Add(unit);
    public void ExitCustomer(Unit unit) => occupants.Remove(unit);
    

}