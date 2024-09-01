    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UnityEngine;
    using UnityEngine.AI;

    public class Cook:  JobBase{

        public Cook(Unit unit): base(unit){

            start = 6;
            end = 10;
            Location = WorldRegister.GetUnderstaffedResturant().gameObject;
            if(Location == null)
                GameObject.Destroy(unit.gameObject);
            structure = Location.GetComponent<Structure>();
            uniform = Resources.Load("Prefabs/Outfits/Cook") as GameObject;
            task = null;
            isInside = true;
        }

        public override void Update(){

            // if(task == null || task.isFinished)
            //     task = new Patrol(unit);
            
            // task.Update();
        }

    }