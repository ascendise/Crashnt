using UnityEngine;

public class Player : MonoBehaviour
{
    private Gyroscope gyro;
    private new Rigidbody rigidbody;

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
}
