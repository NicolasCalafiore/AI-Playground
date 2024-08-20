using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IOManager
{
    public static GameObject GetUnitPrefab()
    {
        return Resources.Load<GameObject>("Prefabs/Unit");
    }
}
