using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickManager
{
    private int TickInterval;
    private float TimeSinceLastTick = 0f;
    public event Action Ticked;

    public TickManager(int tickInterval){
        this.TickInterval = tickInterval;
    }

    public void Tick(){
        TimeSinceLastTick += Time.deltaTime;
        if (TimeSinceLastTick >= TickInterval)
        {
            Ticked?.Invoke();
            TimeSinceLastTick = 0f; // Reset the time since the last tick
        }
    }
}
