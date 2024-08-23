using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IOManager
{
    public static GameObject GetUnitPrefab()
    {
        return Resources.Load<GameObject>("Prefabs/Unit");
    }
    public static GameObject GetUniform(string name)
    {
        return Resources.Load<GameObject>("Prefabs/" + name);
    }

    public static GameObject GetPrefab(string name)
    {
        return Resources.Load<GameObject>("Prefabs/" + name);
    }
}
