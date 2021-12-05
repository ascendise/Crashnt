using System.IO;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{

    private GameObject tile;

    // Start is called before the first frame update
    void Start()
    {
        var tilePath = Path.Combine("Prefabs", "Tile").ToString();
        tile = (GameObject)Resources.Load(tilePath); 
       for(int z = 1; z <= 11; z++)
       {
           var tilePosition = tile.transform.position;
           var tileWidth = tile.GetComponentInChildren<MeshRenderer>().bounds.size.z;
           var zPosition = tilePosition.z + (z * tileWidth);
           var position = tilePosition + new Vector3(0, 0, zPosition);
           var spawned = Instantiate(tile, Vector3.zero, Quaternion.identity, this.transform);
           spawned.transform.localPosition = position;
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
