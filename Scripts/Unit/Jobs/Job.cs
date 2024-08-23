using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Job : MonoBehaviour
{
    public GameObject Outfit;
    public int StartHour;
    public int EndHour;
    public GameObject Actor;
    public GameObject JobLocation;
    public bool isWorking = false;
    protected JobTask CurrentTask = null;

    public Job(GameObject Actor){
        this.Actor = Actor;
    }

    public abstract void FindTask();

    public abstract void Update();


}
