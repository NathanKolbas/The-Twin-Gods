using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float moveSpeed;
    public bool moveRight;

    // Start is called before the first frame update
    void Start()
    {

     if (moveRight) {
         GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
     }
     else{
         GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
     }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
