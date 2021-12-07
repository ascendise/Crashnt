using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    private static Player _instance;
    public static Player Instance 
    {
        get 
        {
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }

    public event EventHandler Crash;
    private Gyroscope gyro;
    private new Rigidbody rigidbody;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {    
        gyro = Input.gyro;
        gyro.updateInterval = 0.5f;
        gyro.enabled = true;
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float speed = 1f;
        float value = gyro.attitude.eulerAngles.z;
        if(value > 110)
        {
            speed *= -1;
        }
        var position = rigidbody.transform.position;
        rigidbody.transform.position = new Vector3(position.x + speed * Time.deltaTime, position.y, position.z);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag.Equals("Obstacle"))
        {
            Crash?.Invoke(this, EventArgs.Empty);
        }
    }


}
