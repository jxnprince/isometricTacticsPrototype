using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileState
{
    public Dictionary<int, Tile> tiles = new Dictionary<int, Tile>();
    public int theSelectedTileId = -1;

    public void SetSelectedTile(int selectedTileId)
    {
        theSelectedTileId = selectedTileId;

        Debug.Log($"MainState, SetSelectedTile, id: {selectedTileId}");
    }

    public void AddTiles(Dictionary<int, Tile> theTiles)
    {
        tiles = theTiles;

    }
}
