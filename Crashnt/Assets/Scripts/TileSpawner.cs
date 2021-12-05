using System.IO;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{

    private GameObject tilePrefab;

    void Awake()
    {
        var tilePath = Path.Combine("Prefabs", "Tile").ToString();
        tilePrefab = (GameObject)Resources.Load(tilePath); 
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnTiles(10);
    }

    private void SpawnTiles(int count)
    {
        for (int z = 1; z <= count; z++)
        {
            var spawned = Instantiate(tilePrefab, Vector3.zero, Quaternion.identity, this.transform);
            Vector3 position = GetNewTilePosition(z);
            spawned.transform.localPosition = position;
        }
    }

    private Vector3 GetNewTilePosition(int index)
    {
        var tilePosition = tilePrefab.transform.position;
        var tileWidth = tilePrefab.GetComponentInChildren<MeshRenderer>().bounds.size.z;
        var zPosition = tilePosition.z + (index * tileWidth);
        var position = tilePosition + new Vector3(0, 0, zPosition);
        return position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
