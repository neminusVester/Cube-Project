using System;
using UnityEngine;

public class CollectibleObject : PoolObject
{
    [Header("Rotation")]
    [SerializeField] private bool rotate = true;
    [SerializeField] private float rotationSpeed = 10f;

    [Header("Collect Effects")]
    [SerializeField] private AudioClip collectSound;
    [SerializeField] private ParticleSystem collectEffect;

    private const float SphereRadius = 0.3f;
    private const int PlayerLayer = 7;
    private int _layerMask = 1 << PlayerLayer;

    private void Update()
    {
        RotateCollectibleObject(rotate);
        CheckPlayerContact();
    }

    private void Collect()
    {
        PlayCollectSound();
        SpawnCollectEffect();
        Destroy();
    }
    
    private void CheckPlayerContact()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, SphereRadius, _layerMask);
        if (hitColliders.Length > 0)
        {
            Collect();
        }
    }
    
    private void PlayCollectSound()
    {
        if (collectSound)
        {
            AudioSource.PlayClipAtPoint(collectSound,transform.position);
        }
    }

    private void SpawnCollectEffect()
    {
        if (collectEffect)
        {
            Instantiate(collectEffect, transform.position, Quaternion.identity);
        }
    }

    private void RotateCollectibleObject(bool isRotation)
    {
        if (isRotation)
        {
            transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime), Space.World);
        }
    }
}
