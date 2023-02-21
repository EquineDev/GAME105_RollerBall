using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerActions : MonoBehaviour
{
    [SerializeField]
    private PlayerInput m_playerInput;
    [SerializeField]
    private float m_ballSpeed = 5f;
    private Rigidbody m_rigidBody;
    private Vector2 m_inputAxis = Vector2.zero;

    private InputAction m_move;
    private InputAction m_fire;

    private Vector3 _startTransform; 
    // Start is called before the first frame update

    private void Awake()
    {
        m_playerInput = new PlayerInput();
    }
    private void OnEnable()
    {
        m_move = m_playerInput.Player.Move;
        m_move.Enable();

        m_fire = m_playerInput.Player.Fire;
        m_fire.Enable();
        m_fire.performed += Jump;
    }

    private void OnDisable()
    {
        m_move.Disable();
        m_fire.Disable();
    }
    void Start()
    {
        
        m_rigidBody = GetComponent<Rigidbody>();
        _startTransform = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        m_inputAxis = m_move.ReadValue<Vector2>().normalized;
    }

    public void ResetPlayer()
    {
        m_rigidBody.isKinematic = true;
        this.transform.position = _startTransform;
        m_rigidBody.velocity = Vector3.zero;
        m_rigidBody.rotation = Quaternion.identity;
        m_rigidBody.isKinematic = false;
    }
    private void FixedUpdate()
    {
        m_rigidBody.AddForce( new Vector3(m_inputAxis.x, 0f, m_inputAxis.y)  * m_ballSpeed);
    }
    private void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("We pressed Jump");
    }
}
