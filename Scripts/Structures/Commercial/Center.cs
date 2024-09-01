using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Center : Commercial
{
    List<GameObject> bodies = new List<GameObject>();
    public Center(){

    }

    public override void Awake(){
        
        employeeCapacity = 10;
        occupantCapacity = 20;
        effectValue = 7;

        WorldRegister.RegisterCenter(this);

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
        int maxVisibleBodies = Mathf.Min(occupants.Count, 7);
        for (int i = 0; i < bodies.Count; i++)
        {
            if (i < maxVisibleBodies)
            {
            bodies[i].SetActive(true);
            }
            else
            {
            bodies[i].SetActive(false);
            }
        }
    }




}
