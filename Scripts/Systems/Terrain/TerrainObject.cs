using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainObject
{
    Vector3 position;
    Vector2 scale;


    public TerrainObject(Vector3 position, Vector2 scale)
    {
        this.position = position;
        this.scale = scale;
    }
}
