using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterCamera : MonoBehaviour
{
    [SerializeField]
    private Transform m_ballTransform;

    [SerializeField] private Vector3 m_offset;

    [SerializeField] private bool UseCustomOffset;

    [SerializeField] private float m_smoothRate = 0.1f;

    private Vector3 m_newTarget;
    private Vector3 m_smoothFollow;
    // Start is called before the first frame update
    void Start()
    {
        if (!UseCustomOffset)
        {
            m_offset = transform.position - m_ballTransform.position;
        }
    }

    private void LateUpdate()
    {
        SmoothFollowUpdate();
    }

    private void SmoothFollowUpdate()
    {
        m_newTarget = m_ballTransform.position + m_offset;
        m_smoothFollow = Vector3.Lerp(transform.position, m_newTarget, m_smoothRate);

        transform.position = m_smoothFollow;
    }
}
