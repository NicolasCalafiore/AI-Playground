using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Resturant : Commercial
{
    List<GameObject> bodies = new List<GameObject>();
    public Resturant(){
        employeeCapacity = 10;
        occupantCapacity = 20;
        effectValue = 15;
    }

    public override void Awake(){
        WorldRegister.RegisterResturant(this);
        GameObject bodiesObject = GameObject.Find("Units");
        if (bodiesObject != null)
        {
            foreach (Transform child in bodiesObject.transform)
            {
                bodies.Add(child.gameObject);
            }
        }
    }


    public override void UpdateOccupancy()
    {
        Debug.Log("Resturant UpdateOccupancy");
        foreach(GameObject body in bodies){
            body.SetActive(false);
        }

        for(int i = 0; i < occupants.Count; i++){
            if(i > 6) break;
            bodies[i].SetActive(true);
        }
        
    }





}
