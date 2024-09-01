using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class VectorTask : JobTask{   
    
    public Vector3 targetVector;

    public VectorTask(Unit unit) : base(unit){
        
    }

}