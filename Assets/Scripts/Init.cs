using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    public static Init instance;
    [SerializeField] private GridManager gridManager = new GridManager();
    public MainState state = new MainState();

    // Start is called before the first frame update
    void Start()
    {
        state.Init();
        gridManager.GenerateGrid(state.tileState);
        state.Log();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
