using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public abstract class UnitState
{
    public Unit unit;

    public UnitState(Unit unit)
    {
        this.unit = unit;
        UpdateStateUI();
        unit.UpdateUI();
    }

    public abstract void SetState();
    public abstract void Update();
    public abstract void UpdateStateUI();
    
}
