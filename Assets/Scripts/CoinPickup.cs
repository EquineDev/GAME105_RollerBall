using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoinPickup : MonoBehaviour
{
    [SerializeField] private int m_coinValue = 1;
    [SerializeField] private AudioClip _audioClip;
    private AudioSource _audioSource;
    private bool _hasBeenPickedup = false;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !_hasBeenPickedup)
        {
            _hasBeenPickedup = true;
            GameManager.Instance.UpdateScore(m_coinValue);
            _audioSource.PlayOneShot(_audioClip);
            Destroy(this.GetComponent<MeshRenderer>());
            DestoryAfterPickup();
            
            
        }
    }

    private void DestoryAfterPickup()
    {
        Destroy(this.gameObject, _audioClip.length);
    }
}
