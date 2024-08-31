using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    bool isInside = false;
    public Structure targetStructure;
    public Vector3 targetPosition;
    public Residential home;
    public string jobStr;

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
        this.targetStructure = structure;
        isInside = true;
    }

    public Vector3 MoveToStructure(Structure structure){
        GetComponent<NavMeshAgent>().SetDestination(structure.transform.Find("Door").position);
        this.targetStructure = structure;
        targetPosition = structure.transform.Find("Door").position;
        return targetPosition;
    }

    public void ExitStructure(){
        Show();
        targetStructure.GetComponent<Structure>().ExitStructure(this);
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
        foreach(Transform child in transform)
            child.gameObject.SetActive(true);
        
    }




    
}
