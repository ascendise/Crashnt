using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public event EventHandler LeftScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
