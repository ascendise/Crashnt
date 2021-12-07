using System;
using UnityEngine;
public class Tile : MonoBehaviour
{
    public event EventHandler LeaveScreen;

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
        var area = obstacleSpawnArea.GetComponent<Renderer>().bounds.size;
        var center = obstacleSpawnArea.transform.position;
        var obstacleSize = obstacle.GetComponent<Renderer>().bounds.size;
        var startPoint = center - area / 2 + obstacleSize / 2;
        var endPoint = center + area / 2;
        var randomPosition = RandomRange(startPoint, endPoint);
        randomPosition.y = obstacle.transform.position.y;
        return randomPosition;
    }

    private Vector3 RandomRange(Vector3 v1, Vector3 v2)
    {
        Vector3 randomVector = new Vector3();
        randomVector.x = UnityEngine.Random.Range(v1.x, v2.x);
        randomVector.y = UnityEngine.Random.Range(v1.y, v2.y);
        randomVector.z = UnityEngine.Random.Range(v1.z, v2.z);
        return randomVector;
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
            OnLeaveScreen(EventArgs.Empty);
        }
    }

    protected virtual void OnLeaveScreen(EventArgs e)
    {
        EventHandler handler = LeaveScreen;
        handler?.Invoke(this, e);
    }

    public void HasObstacle(bool hasObstacle)
    {
        obstacle.SetActive(hasObstacle);
    }


}
