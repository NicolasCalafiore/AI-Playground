using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    bool isInside = false;
    public Structure structure;
    public Residential home;

    void Awake(){

    }

    void Start()
    {
        if(!UnitUtils.FindHousing(gameObject))
            Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
      
    }

    public void EnterStructure(Structure structure){
        Hide();
        structure.GetComponent<Structure>().EnterStructure(this);
        isInside = true;
    }

    public Vector3 MoveToStructure(Structure structure){
        GetComponent<NavMeshAgent>().SetDestination(structure.transform.Find("Door").position);
        this.structure = structure;
        return structure.transform.Find("Door").position;
    }

    public void ExitStructure(){
        Show();
        structure.GetComponent<Structure>().ExitStructure(this);
        isInside = false;
    }

    public void GoToVectorPosition(Vector3 position){
        GetComponent<NavMeshAgent>().SetDestination(position);
    }

    public void Hide(){
        foreach(Transform child in transform){
            child.gameObject.SetActive(false);
        }
    }

    public void Show(){
        foreach(Transform child in transform){
            child.gameObject.SetActive(true);
        }
    }



    
}
