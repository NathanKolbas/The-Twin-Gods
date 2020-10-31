using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool inRange;
    public float range;
    private float distance;
    public float attackRange;
    private bool inAttackRange;

    void Start(){
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update(){
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;
        Debug.Log(angle);

        Vector3 distanceVector = player.position - transform.position;
        distance = Mathf.Sqrt(Mathf.Pow(distanceVector.x, 2) + Mathf.Pow(distanceVector.y, 2));

        if (distance <= range && distance > attackRange) {
            inRange = true;
        }

        if (distance <= attackRange) {
            inAttackRange = true;
        }

        
    }

    private void FixedUpdate(){        
        if (inRange) {
            moveCharacter(movement);
        }
    }

    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
