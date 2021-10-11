using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour{
    GameObject cube;

    public void Initialize()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);  //Create basic cube
        cube.AddComponent<BoxCollider>();  //Add collision.  Maybe change later?
    }
}
