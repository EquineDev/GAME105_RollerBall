using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class yMovement : MonoBehaviour
{
    public float Speed = 0f;

    private Rigidbody Rigidbody;
    private float MovementX = 0f;
    private float MovementY = 0f; 
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        Vector3 Force = new Vector3(MovementX, 0.0f, MovementY);
        
        Rigidbody.AddForce(Force *Speed);
    }

    private void OnMove(InputValue MovementValue)
    {
        Vector2 Movement = MovementValue.Get<Vector2>();

        MovementX = Movement.x;
        MovementY = Movement.y;
    }
}
