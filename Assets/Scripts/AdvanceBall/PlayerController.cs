using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private InputAction m_moveControl;
    [SerializeField]
    private float m_ballSpeed = 5f;
    private Rigidbody m_rigidBody;
    private Vector2 m_inputAxis = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        m_moveControl.Enable();
    }

    private void OnDisable()
    {
        m_moveControl.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        m_inputAxis = m_moveControl.ReadValue<Vector2>().normalized;
    }

    private void FixedUpdate()
    {
        m_rigidBody.AddForce( m_inputAxis * m_ballSpeed);
    }
}
