using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Await : AwaitableTask{   

    public Await(Unit unit) : base(unit){

    }


    public override void Update()
    {
        if(isStarted)
            timeWaited += Time.deltaTime;

        if(timeWaited >= waitTime)
            isFinished = true;
    }

    public void SetAwaitTime(int timeToWait) => waitTime = timeToWait;
    public void StartTimer() => isStarted = true;
    
    


}