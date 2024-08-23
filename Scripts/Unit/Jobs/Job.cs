using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Job : MonoBehaviour
{
    public GameObject Outfit;
    public int StartHour;
    public int EndHour;
    public GameObject Actor;
    public GameObject JobLocation;
    public bool isWorking = false;

    public Job(GameObject Actor){
        this.Actor = Actor;
    }


}
