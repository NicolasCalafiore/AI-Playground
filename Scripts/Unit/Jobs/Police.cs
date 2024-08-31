using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class Police:  JobBase{

    public Police(Unit unit): base(unit){
        start = 0;
        end = 24;
        Location = WorldRegister.GetUnderstaffedPoliceStation().gameObject;
        structure = Location.GetComponent<Structure>();
        uniform = Resources.Load("Prefabs/Outfits/Police") as GameObject;
        task = null;
    }

    public override void Update(){
        if(task == null || task.isFinished){
            task = new Patrol(unit);
        }
        
        task.Update();
    }

}