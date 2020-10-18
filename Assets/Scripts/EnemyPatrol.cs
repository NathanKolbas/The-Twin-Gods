using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float moveSpeed;
    public bool moveRight;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool onWall;

    private bool notAtEdge;
    public Transform edgeCheck;

    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        onWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

        if (onWall || !notAtEdge) {
            moveRight = !moveRight;
        }

        if (moveRight) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            _rigidbody2D.velocity = new Vector2(moveSpeed, _rigidbody2D.velocity.y);
        }
        else{
            transform.localScale = new Vector3(1f, 1f, 1f);
            _rigidbody2D.velocity = new Vector2(-moveSpeed, _rigidbody2D.velocity.y);
        }
    }
}
