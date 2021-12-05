using System;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField]
    private Tile tilePrefab;
    private List<Tile> tiles = new List<Tile>();

    // Start is called before the first frame update
    void Start()
    {
        SpawnTiles(10);
    }
    
    private void SpawnTiles(int count)
    {
        for (int z = 0; z <= count + 1; z++)
        {
            SpawnTile();
        }
    }

    private void SpawnTile()
    {
        var tile = GetLastTile();
        var tileWidth = tile.GetComponentInChildren<Renderer>().bounds.size.z;
        Tile spawned = Instantiate(tilePrefab, tile.transform.position + new Vector3(0, 0, tileWidth), Quaternion.identity, this.transform);
        tiles.Add(spawned);
        spawned.LeftScreen += Tile_OnLeftScreen;
    }

    private Tile GetLastTile()
    {
        Tile tile;
        if (tiles.Count > 0)
        {
            tile = tiles[tiles.Count - 1];
        }
        else
        {
            tile = tilePrefab;
        }

        return tile;
    }

    private void Tile_OnLeftScreen(object sender, EventArgs e)
    {
        var tile = (Tile)sender;
        tiles.Remove(tile);
        Destroy(tile);
        SpawnTile();
    }
}
