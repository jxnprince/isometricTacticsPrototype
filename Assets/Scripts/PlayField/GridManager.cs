using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour{
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;
    public Dictionary<Vector3, Tile> tiles;


    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid(){
        tiles = new Dictionary<Vector3, Tile>();
        for (int x = 0; x < _width; x++){
            for (int z = 0; z < _height; z++){
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, 0, z), Quaternion.identity);
                spawnedTile.name = $"Tile ({x},{z})";

            var isOffset = (x % 2 != z % 2);
            spawnedTile.Init(isOffset);

            tiles[new Vector3(x, 0, z)] = spawnedTile;
            }
        }
    }

    public Tile GetTileAtPosition(Vector3 pos){
        if (tiles.TryGetValue(pos, out var tile)){
            return tile;
        }
        return null;
    }
}
