using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour{
    GameObject cube;

    void Start()
    {
        GameObject cube = new GameObject();
        cube.AddComponent<MeshFilter>();
        cube.AddComponent<BoxCollider>();
    }
}
