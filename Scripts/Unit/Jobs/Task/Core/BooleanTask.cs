using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class BooleanTask : JobTask{   
    
    public bool condition;

    public BooleanTask(Unit unit) : base(unit){
        
    }

}