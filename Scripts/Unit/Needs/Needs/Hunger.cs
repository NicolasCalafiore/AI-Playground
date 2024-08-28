using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hunger : Need{
    public Hunger(int value, int rate, int threshold, int satisfied) : base(value, rate, threshold, satisfied){

    }

}