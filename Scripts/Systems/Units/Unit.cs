using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    public UnitState state;
    public GameObject target;
    private TextMeshPro stanceText;
    public GameObject awarenessSphere;
    public GameObject engageSphere;
    private GameObject body;
    public NavMeshAgent navMeshAgent; // Add a reference to the NavMeshAgent component
    static List<Color> colors = new List<Color> { Color.red, Color.blue, Color.green, Color.yellow, Color.cyan, Color.magenta, Color.white, Color.black, Color.gray };
    void Awake()
    {
        SubscribeToAwakeEvents();
        FindUnitGameObjects();
        state = new HoldingState(this);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        state.Update();
        state.SetStance();
        UpdateStanceText();
    }

    void OnDestroy() =>  UnitManager.OnSetStance -= SetStance;
    
    public void SetStance()
    {
        state.SetStance();
        UpdateStanceText();
    }
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

    public void UpdateStanceText()
    {
        stanceText.text = state.GetType().Name;
    }

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
    }


    
}
