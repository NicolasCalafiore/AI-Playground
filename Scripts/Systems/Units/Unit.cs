using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using static UnitEnums;

public class Unit : MonoBehaviour
{
    private UnitState state;
    private TextMeshPro stanceText;
    private GameObject awarenessSphere;
    private GameObject engageSphere;
    private GameObject body;
    private NavMeshAgent navMeshAgent; // Add a reference to the NavMeshAgent component
    static List<Color> colors = new List<Color> { Color.red, Color.blue, Color.green, Color.yellow, Color.cyan, Color.magenta, Color.white, Color.black, Color.gray };
    private GameObject target = null;
    void Awake()
    {
        Debug.Log("Unit Awake");
        UnitManager.OnSetStance += SetStance;
        stanceText = transform.Find("Stance").GetComponent<TextMeshPro>();
        awarenessSphere = transform.Find("AwarenessSphere").gameObject;
        engageSphere = transform.Find("EngageSphere").gameObject;
        body = transform.Find("Body").gameObject;
        Color color = colors[Random.Range(0, colors.Count)];
        color = new Color(color.r, color.g, color.b, 0.2f);
        body.GetComponent<Renderer>().material.color = color;
        awarenessSphere.gameObject.transform.Find("Sphere").GetComponent<Renderer>().material.color = color;
        navMeshAgent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(target != null && state == UnitState.Tracking){
            navMeshAgent.SetDestination(target.transform.position);
            if(Vector3.Distance(transform.position, target.transform.position) <  engageSphere.transform.Find("Sphere").localScale.x / 2 - ((engageSphere.transform.Find("Sphere").localScale.x / 2) * .1f)){
                Debug.Log("Engaging from main");
                SetStance();
            }
            
        }
        

    }

    void OnDestroy()
    {
        UnitManager.OnSetStance -= SetStance;
    }

    public void SetStance()
    {

        int unitsInAwareness = UnitsInAwareness();
        int unitsInEngage = UnitsInEngage();
        Debug.Log("Units in awareness: " + unitsInAwareness);
        Debug.Log("Units in engage: " + unitsInEngage);
        if(unitsInEngage > 0){
            state = UnitState.Engaging;
            navMeshAgent.ResetPath();
            navMeshAgent.velocity = Vector3.zero;
            GameObject threat = GetClosestUnit(engageSphere);

            if(threat != null)
                target = threat;
        }
        else if(unitsInAwareness > 0 && state != UnitState.Holding){
            state = UnitState.Tracking;
            GameObject threat = GetClosestUnit(awarenessSphere);
            if(threat != null)
                target = threat;
        }
        else state = UnitState.Holding;

        UpdateStanceText();

    }

    public int UnitsInAwareness()
    {
        Collider[] colliders = Physics.OverlapSphere(awarenessSphere.transform.position, awarenessSphere.transform.Find("Sphere").localScale.x / 2);
        Debug.Log("Aware Distance: " + awarenessSphere.transform.Find("Sphere").localScale.x / 2);

        int sum = 0;
        foreach (Collider collider in colliders)
            if (collider.gameObject.tag == "Unit" && collider.gameObject.transform.parent.gameObject != gameObject)
                sum++;
        
        return sum;
    }

    public int UnitsInEngage()
    {
        Collider[] colliders = Physics.OverlapSphere(engageSphere.transform.position, engageSphere.transform.Find("Sphere").localScale.x / 2);
        Debug.Log("Engage Distance: " + engageSphere.transform.Find("Sphere").localScale.x / 2);

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

    private IEnumerator EnableAwarenessSphereTemporarily()
    {
        awarenessSphere.SetActive(true);
        yield return new WaitForSeconds(2f);
        awarenessSphere.SetActive(false);
    }

    private IEnumerator EnableEngageSphereTemporarily()
    {
        engageSphere.SetActive(true);
        yield return new WaitForSeconds(2f);
        engageSphere.SetActive(false);
    }

    private void UpdateStanceText()
    {
        stanceText.text = state.ToString();
        if(state == UnitState.Tracking)
            stanceText.color = Color.yellow;
        else if(state == UnitState.Holding)
            stanceText.color = Color.blue;
        else if(state == UnitState.Engaging)
            stanceText.color = Color.red;
        else
            stanceText.color = Color.white;
    }
}
