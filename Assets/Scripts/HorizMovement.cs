using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizMovement : MonoBehaviour {
    public float min = -5f;
    public float max = 5f;
    public float speed = 5f;

    // Use this for initialization
    void Start () {

        min = transform.position.x + min;
        max = transform.position.x + max;
        speed = 5f;

    }

    // Update is called once per frame
    void Update ()
    {
        var position = transform.position;
        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, max - min) + min, position.y, position.z);
    }
       
}
