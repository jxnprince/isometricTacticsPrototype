using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour{
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;


    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid(){
        for (int x = 0; x < _width; x++){
            for (int z = 0; z < _height; z++){
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, 0, z), Quaternion.identity);
                spawnedTile.name = $"Tile ({x},{z})";
            }
        }
    }
}
