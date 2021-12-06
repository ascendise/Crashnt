using System;
using UnityEngine;
public class Tile : MonoBehaviour
{
    public event EventHandler LeftScreen;

    [SerializeField]
    private GameObject obstacle;
    [SerializeField]
    private GameObject obstacleSpawnArea;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        obstacle.transform.position = spawnPosition;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        var size = obstacleSpawnArea.GetComponent<Renderer>().bounds.size;
        var area = obstacleSpawnArea.transform.position;
        var randomPosition = new Vector3();
        randomPosition.x = UnityEngine.Random.Range(area.x - size.x / 2, area.x + size.x / 2);
        randomPosition.y = obstacle.transform.position.y;
        randomPosition.z = UnityEngine.Random.Range(area.z + size.z / 2, area.z - size.z / 2);
        return randomPosition;
    }

    // Update is called once per framelocalPosition
    void Update()
    {
        float speed = -20f;
        this.transform.position += new Vector3(0, 0, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag.Equals("TileEater"))
        {
            OnLeftScreen(EventArgs.Empty);
        }
    }

    protected virtual void OnLeftScreen(EventArgs e)
    {
        EventHandler handler = LeftScreen;
        handler?.Invoke(this, e);
    }


}
