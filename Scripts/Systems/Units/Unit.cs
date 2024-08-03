using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    public UnitState state;
    public GameObject target;
    public TextMeshPro stanceText;
    public GameObject awarenessSphere;
    public GameObject engageSphere;
    public GameObject body;
    public NavMeshAgent navMeshAgent; // Add a reference to the NavMeshAgent component
    public TextMeshPro healthText;
    public TextMeshPro powerText;
    public TextMeshPro attackSpeedText;
    public event Action OnDeath;
    public int power = 20;
    public int health = 10;
    public float attackSpeed = 5f;
        
    public int UnitsInSphere(GameObject sphere){
        Collider[] colliders = Physics.OverlapSphere(sphere.transform.position, sphere.transform.Find("Sphere").localScale.x / 2);
        int sum = 0;
        foreach (Collider collider in colliders)
            if (collider.gameObject.tag == "Unit" && collider.gameObject.transform.parent.gameObject != gameObject)
                sum++;
        
        return sum;
    }
    public GameObject GetClosestUnit(GameObject sphere)
    {
        Collider[] colliders = Physics.OverlapSphere(sphere.transform.position, sphere.transform.Find("Sphere").localScale.x / 2);

        GameObject closestUnit = null;
        float closestDistance = Mathf.Infinity;
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag == "Unit" && collider.gameObject.transform.parent.gameObject != gameObject)
            {
                float distance = Vector3.Distance(collider.transform.position, transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestUnit = collider.gameObject.transform.parent.gameObject;
                }
            }
        }

        return closestUnit;
    }
    public void SetStance() => state.SetState();

    private void Awake()
    {
        SubscribeToAwakeEvents();
        FindUnitGameObjects();
        state = new HoldingState(this);
    }

    private void Start(){}

    private void Update()
    {
        if(health <= 0)
            Death();

        state.Update();
        state.SetState();
    }

    private void OnDestroy() =>  UnitManager.OnSetStance -= SetStance;

    private void SubscribeToAwakeEvents()
    {
        UnitManager.OnSetStance += SetStance;
    }

    private void FindUnitGameObjects(){
        stanceText = transform.Find("Stance").GetComponent<TextMeshPro>();
        awarenessSphere = transform.Find("AwarenessSphere").gameObject;
        engageSphere = transform.Find("EngageSphere").gameObject;
        body = transform.Find("Body").gameObject;
        navMeshAgent = GetComponent<NavMeshAgent>();
        healthText = transform.Find("Health").GetComponent<TextMeshPro>();
        powerText = transform.Find("Power").GetComponent<TextMeshPro>();
        attackSpeedText = transform.Find("AttackSpeed").GetComponent<TextMeshPro>();
    }

    public void Death()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }

    public void UpdateUI()
    {
        if(stanceText == null)
            return;
            
        healthText.text = "Health: " + health;
        powerText.text = "Power: " + power;
        attackSpeedText.text = "Attack Speed: " + attackSpeed;

        Vector3 cameraPosition = Camera.main.transform.position;
        Vector3 lookDirection = cameraPosition - transform.position;
        Quaternion rotation = Quaternion.LookRotation(lookDirection);
        stanceText.transform.rotation = rotation * Quaternion.Euler(0, 180, 0);
        healthText.transform.rotation = rotation * Quaternion.Euler(0, 180, 0);
        powerText.transform.rotation = rotation * Quaternion.Euler(0, 180, 0);
        attackSpeedText.transform.rotation = rotation * Quaternion.Euler(0, 180, 0);
    }

    
}
