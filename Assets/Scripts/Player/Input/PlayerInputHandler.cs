﻿using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 100.0f)] private float speed = 50.0f;

    private Animator _animator;
    // private Rigidbody _rigidbody;
    private Vector2 _movement;
    private static readonly int X = Animator.StringToHash("x");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    private void FixedUpdate()
    {
        // _rigidbody.AddForce(_movement * speed);
        transform.Translate(_movement);
    }
    
    
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        Vector2 movementInput = speed * context.ReadValue<Vector2>();
        _movement = new Vector2(movementInput.x, movementInput.y);
        _movement *= Time.deltaTime;
        AnimateMovment(movementInput);
    }
    
    private void AnimateMovment(Vector2 direction) 
    {
        _animator.SetFloat(X, direction.x);
    }
}
