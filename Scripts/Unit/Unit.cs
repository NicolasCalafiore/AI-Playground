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
    [SerializeField] private int Social_Debug;
    [SerializeField] private string activity;
    [SerializeField] private string jobStr;
    [SerializeField] private bool MakeSleepy = false;
    [SerializeField] private bool MakeHungry = false;
    [SerializeField] private bool MakeSocial = false;
    Structure occupiedStructure = null;
    public GameObject targetStructure = null;
    public Job job;

    void Awake(){
        job = new Unemployed(gameObject);

        FindComponents();
        needs = new Needs();
        _ActivityManager.SetActivity();

        if(!UnitUtils.FindHousing(gameObject))
            Destroy(gameObject);
        



    }

    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        DebugOverrides();

        if(job is not Unemployed && !job.isWorking && TimeManager.instance.hour >= job.StartHour && TimeManager.instance.hour < job.EndHour)
            _ActivityManager.SetActivity();

        _ActivityManager.Update();
        needs.Update();
    }
    void DebugOverrides(){
        Social_Debug = needs.Social;
        Hunger_Debug = needs.Hunger;
        Sleep_Debug = needs.Sleep;

        jobStr = job.GetType().Name;
        activity = _ActivityManager.CurrentActivity.GetType().Name;

        if(MakeHungry)
            needs.Hunger = needs.HungerThreshold + 1;
        if(MakeSleepy)
            needs.Sleep = needs.SleepThreshold + 1;
        if(MakeSocial)
            needs.Social = needs.SocialThreshold + 1;


        MakeHungry = false;
        MakeSleepy = false;
        MakeSocial = false;
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
        SetVisiblity(false);
        structure.AddOccupant(gameObject);
        occupiedStructure = structure;
    }

    public void ExitStructure(){
        occupiedStructure.RemoveOccupant(gameObject);
        SetVisiblity(true);
    }

    public void Stop(){
        Agent.ResetPath();
        Agent.speed = 0;
    }

    public void WearOutfit(bool isWearing){
        if(isWearing){
            GameObject outfit = Instantiate(job.Outfit);
            outfit.transform.SetParent(transform);
            outfit.transform.localPosition = Vector3.zero;
        }
        else{
            foreach (Transform child in transform)
            {
                if(child.gameObject.tag == "Outfit")
                    Destroy(child.gameObject);
            }
        }
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
