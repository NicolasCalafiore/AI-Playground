using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    
    GameObject Home = null;
    NavMeshAgent Agent;
    ActivityManager _ActivityManager;
    public Needs needs;
    [SerializeField] private int Hunger_Debug;
    [SerializeField] private int Sleep_Debug;
    [SerializeField] private string activity;
    [SerializeField] private bool MakeSleepy = false;
    [SerializeField] private bool MakeHungry = false;
    Structure occupiedStructure = null;
    public GameObject targetStructure = null;

    void Awake(){
        FindComponents();
        needs = new Needs();
        _ActivityManager.SetActivity();
        Debug.Log("Awake");

        if(!UnitUtils.FindHousing(gameObject)){
            Debug.Log("No housing found for unit");
            Destroy(gameObject);
        }
    }

    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        DebugOverrides();


        activity = _ActivityManager.CurrentActivity.GetType().Name;


        _ActivityManager.Update();
        needs.Update();
    }
    void DebugOverrides(){
        Hunger_Debug = needs.Hunger;
        Sleep_Debug = needs.Sleep;

        if(MakeHungry)
            needs.Hunger = _ActivityManager.GetHungerThreshold() + 1;
        if(MakeSleepy)
            needs.Sleep = _ActivityManager.GetSleepThreshold() + 1;

        MakeHungry = false;
        MakeSleepy = false;
    }
    void FindComponents(){
        Agent = GetComponent<NavMeshAgent>();
        _ActivityManager = new ActivityManager(this);
    }
    public void SetHome(GameObject home){
        this.Home = home;
    }

    public GameObject GetHome(){
        return Home;
    }

    public void MoveToStructure(GameObject structure){
        targetStructure = structure;
        Debug.Log("Moving to Structure");
        Agent.SetDestination(structure.transform.Find("Door").position);
    }

    public Vector3 StructureDoorPosition(GameObject structure){
        return structure.transform.Find("Door").position;
    }

    public void MoveToPosition(Vector3 position){
        Agent.SetDestination(position);
    }

    public void EnterStructure(GameObject structureGO){
        Structure structure = structureGO.GetComponent<Structure>();
        Debug.Log("Entering Structure");
        SetVisiblity(false);
        structure.AddOccupant(gameObject);
        occupiedStructure = structure;
    }

    public void ExitStructure(){
        Debug.Log("Exiting Structure");
        occupiedStructure.RemoveOccupant(gameObject);
        SetVisiblity(true);
    }

    public void Stop(){
        Agent.ResetPath();
        Agent.speed = 0;
    }

    void SetVisiblity(bool visible){
        if(visible){
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
        else{
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

}
