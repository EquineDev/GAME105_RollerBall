using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject m_player;
    private Vector3 m_offset;

    // Start is called before the first frame update
    void Start()
    {
        m_offset = transform.position - m_player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = m_player.transform.position + m_offset;
    }
}
