using System;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField]
    private Tile tilePrefab;
    private List<Tile> tiles = new List<Tile>();
    private int obstacleDistance = 5;
    private int tileCounter = 1;

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
        var tile = GetNewTile();
        tiles.Add(tile);
        tile.LeaveScreen += Tile_OnLeaveScreen;
        if(tileCounter % obstacleDistance == 0)
        {
            tile.HasObstacle(true);
            tileCounter = 1;
        }
        tileCounter++;
    }

    private Tile GetNewTile()
    {
        Vector3 distance = new Vector3(0, 0, 0);
        Tile lastTile = tilePrefab;
        if (tiles.Count > 0)
        {
            lastTile = tiles[tiles.Count - 1];
            var tileLength = lastTile.GetComponentInChildren<Renderer>().bounds.size.z;
            distance = new Vector3(0, 0, tileLength);
        }
        Tile newTile = Instantiate(tilePrefab, lastTile.transform.position + distance, Quaternion.identity);
        return newTile;
    }

    private void Tile_OnLeaveScreen(object sender, EventArgs e)
    {
        var tile = (Tile)sender;
        tiles.Remove(tile);
        Destroy(tile.gameObject);
        SpawnTile();
    }
}
