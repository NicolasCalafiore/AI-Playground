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
    [SerializeField] bool MakeHungry;
    [SerializeField] bool MakeTired;
    [SerializeField] bool MakeSocial;
    private GameObject instantiatedOutfit;

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
        OverrideDebugs();
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

        targetPosition = position;
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
    
    public void OverrideDebugs(){
        if(MakeHungry)
            GetComponent<Needs>().hunger.value =  GetComponent<Needs>().hunger.threshold;
        
        if(MakeTired)
            GetComponent<Needs>().energy.value =  GetComponent<Needs>().energy.threshold;

        if(MakeSocial)
            GetComponent<Needs>().social.value =  GetComponent<Needs>().social.threshold;

        MakeHungry = false;
        MakeTired = false;
        MakeSocial = false;
    }

    public void SetOutfit(GameObject outfitPrefab){
        if (instantiatedOutfit != null)
        {
            Destroy(instantiatedOutfit);  // Destroy any existing outfit
        }
        instantiatedOutfit = Instantiate(outfitPrefab, gameObject.transform);
        instantiatedOutfit.transform.localPosition = Vector3.zero;
    }

    public void ShowOutfit(){
        if (instantiatedOutfit != null)
        {
            instantiatedOutfit.SetActive(true);
        }
    }

    public void RemoveOutfit(){
        if (instantiatedOutfit != null)
        {
            Destroy(instantiatedOutfit);
            instantiatedOutfit = null;  // Reset the reference
        }
    }

    
}
