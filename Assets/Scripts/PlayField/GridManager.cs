using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour{

    [SerializeField] private int _width, _height; //Total width and height for a square playfield
    [SerializeField] private Tile _tilePrefab; //Selects a prefab tile in Unity
    public Dictionary<Vector3, Tile> tiles; //Dictionary to track reference all created tiles


    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid(){
        tiles = new Dictionary<Vector3, Tile>();
        for (int x = 0; x < _width; x++){// Iterate over height
            for (int z = 0; z < _height; z++){//Iterate over the width.  Must be z axis and not y.
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, 0, z), Quaternion.identity);//creates new tile at a specific Vector.  Y is always a default of 0 on single level terrain.
                spawnedTile.name = $"Tile ({x},{z})";//Names Game Object created in unity instance.

            var isOffset = (x % 2 != z % 2);//determines if it is an even or odd tile
            spawnedTile.Init(isOffset);//Init property assigns textures and materials to tiles.

            tiles[new Vector3(x, 0, z)] = spawnedTile; //stores the tile and it's vector in the dictionary.
            }
        }
    }

    public Tile GetTileAtPosition(Vector3 pos){
        if (tiles.TryGetValue(pos, out var tile)){ //If the tile exists, return it,
            return tile;
        }
        return null;
    }
}
