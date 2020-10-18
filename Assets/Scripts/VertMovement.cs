using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertMovement : MonoBehaviour {
    public float min = -5f;
    public float max = 5f;
    public float speed = 5f;

    // Use this for initialization
    void Start () {

        min = transform.position.y + min;
        max = transform.position.y + max;
        speed = 5f;

    }

    // Update is called once per frame
    void Update ()
    {
        var position = transform.position;
        transform.position = new Vector3(position.x, Mathf.PingPong(Time.time * speed, max - min) + min, position.z);
    }
       
}
