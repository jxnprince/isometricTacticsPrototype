using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

    public static GridManager instance;
    [SerializeField] private int _width, _height; //Total width and height for a square playfield
    [SerializeField] private Tile _tilePrefab; //Selects a prefab tile in Unity
    public Dictionary<int, Tile> tiles; //Dictionary to track reference all created tiles

    public void GenerateGrid(MainState state){
        tiles = new Dictionary<int, Tile>();

        int i = 1;
        for (int x = 0; x < _width; x++){// Iterate over height
            for (int z = 0; z < _height; z++){//Iterate over the width.  Must be z axis and not y.
                var tile = Instantiate(_tilePrefab, new Vector3(x, 0, z), Quaternion.identity);//creates new tile at a specific Vector.  Y is always a default of 0 on single level terrain.
                tile.position = new Vector3(x, 0, z);//Names Game Object created in unity instance.
                tile.id = i;
                tile.name = $"{i}";
                i += 1;
                var isOffset = (x % 2 != z % 2);//determines if it is an even or odd tile
                tile.Init(isOffset, state);//Init property assigns textures and materials to tiles.

                tiles[tile.id] = tile; //stores the tile and it's vector in the dictionary.
                tile.transform.parent = gameObject.transform;

                //Debug.Log(tile);
            }
        }

        //tileState.Add("tiles", tiles); // maybe useful later?
    }

    //public Tile GetTileAtPosition(Vector3 pos){
    //    if (tiles.TryGetValue(pos, out var tile)){ //If the tile exists, return it,
    //        return tile;
    //    }
    //    return null;
    //}
}
