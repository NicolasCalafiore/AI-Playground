using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static float UniversalGameSpeed = 1f;
    public static TimeManager instance;
    public float time = 0f;
    public float minuteLength = .2083f;
    public int day = 0;
    public int hour = 8;
    public int minute = 0;
    
    //1 day = 5 minutes
    //1 hour = 12 seconds
    //1 minute = .2083 seconds

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        time += Time.deltaTime * UniversalGameSpeed;

        if(time >= minuteLength){
            time = 0f;
            minute++;
            if(minute >= 60){
                minute = 0;
                hour++;
                if(hour >= 24){
                    hour = 0;
                    day++;
                }
            }
        }

        GameObject.Find("Time").GetComponent<TMPro.TextMeshProUGUI>().text = "Day: " + day + " Hour: " + hour + " Minute: " + minute;
    }
    
    public void SetX1Speed() => UniversalGameSpeed = 1f;
    public void SetX4Speed() => UniversalGameSpeed = 4f;
    public void SetX8Speed() =>  UniversalGameSpeed = 8f;
    

}
