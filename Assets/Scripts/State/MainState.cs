using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainState
{

    public TileState tileState = new TileState();

    public void Init()
    {
        Debug.Log("MainState, Innit?");
        //Dictionary tileState = new Dictionary();
    }

    public void Log()
    {
        Debug.Log("MainState, Log?");
        //var output = JsonUtility.ToJson(tileState["tiles"][1], true);
        //Debug.Log(output);
    }

}