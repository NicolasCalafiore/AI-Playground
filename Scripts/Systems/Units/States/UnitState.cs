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
    }

    public abstract void SetStance();
    public abstract void Update();

}
