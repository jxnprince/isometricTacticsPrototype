using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; //Added dependency to access objects in the Unity editor

public class MenuScripts
{

    [MenuItem("Tools/Assign Tile Material")] //Makes the script availible at tools > Assign Tile Material
    public static void AssignTileMaterial() //MenuScripts programatically adds a material to all tiles on a game board
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");  //Grab all tiles from Unity and put them in an array
        Material newMaterial = Resources.Load<Material>("Tile"); //Reference to the material to be applied

        foreach (GameObject t in tiles)
        {
            t.GetComponent<Renderer>().material = newMaterial; //Assigns material to each element in the tiles array
        }
    }

}
