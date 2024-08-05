using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AI : MonoBehaviour
{  
    int id;
    public int health;
    public int attackSpeed;
    public int attackDamage;
    public int healSpeed;
    public AIState state;
    static int nextId = 0;
    TextMeshPro StateText;
    TextMeshPro IDText;
    TextMeshPro HealthText;
    TextMeshPro APASText;
    TextMeshPro BStrength;
    public GameObject awareSphere;
    public GameObject engageSphere;
    public GameObject body;
    public NavMeshAgent navAgent;
    public GameObject target;
    public int team;
    public Color teamColor;


    
    void Awake(){
        id = nextId;
        nextId++;
        InitializeValues();
        FindGameObjects();
    }

    void Start(){
        state = new Idle(this);
    }

    void Update(){
        if(health <= 0){
            
            Destroy(gameObject);
        }
        state.Update();
        state.SetState();
        UpdateUI();
    }


    private void InitializeValues()
    {
        health = 100;
        attackSpeed = UnityEngine.Random.Range(1, 10);
        attackDamage = UnityEngine.Random.Range(5, 40);
        healSpeed = UnityEngine.Random.Range(1, 15);
    }

    void FindGameObjects(){

        body = transform.Find("Body").gameObject;
        StateText = transform.Find("State").GetComponent<TextMeshPro>();
        IDText = transform.Find("ID").GetComponent<TextMeshPro>();
        navAgent = GetComponent<NavMeshAgent>();
        awareSphere = transform.Find("AwareSphere").transform.Find("Sphere").gameObject;
        engageSphere = transform.Find("EngageSphere").transform.Find("Sphere").gameObject;
        HealthText = transform.Find("Health").GetComponent<TextMeshPro>();
        APASText = transform.Find("APAS").GetComponent<TextMeshPro>();
        BStrength = transform.Find("BStrength").GetComponent<TextMeshPro>();


    }

    void UpdateUI(){
        StateText.text = state.name;
        IDText.text = id.ToString();
        HealthText.text = health.ToString();
        APASText.text = attackDamage.ToString() + " " + attackSpeed.ToString();
        BStrength.text = state.outputValue.ToString();
        
        Vector3 cameraPosition = Camera.main.transform.position;
        StateText.transform.LookAt(-cameraPosition);
        IDText.transform.LookAt(-cameraPosition);
        HealthText.transform.LookAt(-cameraPosition);
        APASText.transform.LookAt(-cameraPosition);
        
    }
}
