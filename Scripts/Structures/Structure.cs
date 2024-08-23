using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Structure : MonoBehaviour
{
    [SerializeField] protected int Capacity;
    [SerializeField] protected int OccupantNum = 0;
    [SerializeField] protected int ResidentNum = 0;
    protected List<GameObject> Residents = new List<GameObject>();
    protected List<GameObject> Occupants = new List<GameObject>();


    public bool AddResident(GameObject resident)
    {
        if (ResidentNum < Capacity)
        {
            ResidentNum++;
            Residents.Add(resident);
            return true;
        }
        return false;
    }

    public void RemoveResident(GameObject resident)
    {
        ResidentNum--;
        Residents.Remove(resident);
    }

    public bool AddOccupant(GameObject occupant)
    {
        if (Occupants.Count < Capacity)
        {
            OccupantNum++;
            Occupants.Add(occupant);
            return true;
        }
        return false;
    }

    public void RemoveOccupant(GameObject occupant)
    {
        OccupantNum--;
        Occupants.Remove(occupant);
    }

    public int GetCapacity()
    {
        return Capacity;
    }

    public List<GameObject> GetOccupants()
    {
        return Residents;
    }

    public bool IsResidentsFull(){
        return Residents.Count == Capacity;
    }


}
