using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance {get; private set;}
    public float Score {get; private set;}
    public float Highscore {get; private set;}

    public event EventHandler Crash;
    private Gyroscope gyro;

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
        SetupGyro();
        this.Highscore = PlayerPrefs.GetFloat("highscore");
    }

    private void SetupGyro()
    {
        gyro = Input.gyro;
        gyro.updateInterval = 0.5f;
        gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Score += 0.01f * Time.deltaTime;
        Move();
    }

    private void Move()
    {
        var movement = gyro.rotationRate.z * -2f * Time.deltaTime;
        var characterController = this.GetComponent<CharacterController>();
        characterController.Move(new Vector3(movement, 0, 0));
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag.Equals("Obstacle"))
        {
            OnCrash(EventArgs.Empty);
        }
    }

    protected virtual void OnCrash(EventArgs e)
    {
        SaveScore();
        this.gameObject.SetActive(false);
        EventHandler handler = Crash;
        handler?.Invoke(this, e);
    }

    private void SaveScore()
    {
        if (this.Score > this.Highscore)
        {
            this.Highscore = this.Score;
            PlayerPrefs.SetFloat("highscore", this.Highscore);
            PlayerPrefs.Save();
        }
    }
}







