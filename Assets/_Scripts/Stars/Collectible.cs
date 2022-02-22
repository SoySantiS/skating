using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private AudioSource collect;
    [SerializeField] private ParticleSystem pickParticleSystem;
    [SerializeField] bool specialStar = false;

    private void Awake()
    {
        pickParticleSystem = GetComponentInParent<ParticleSystem>();  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (specialStar)
            {
                PointsManager.SharedInstance.AddPoints(100);
            }
            else
            {
                PointsManager.SharedInstance.AddPoints(50);
            }
            pickParticleSystem.Play();
            
            collect.Play();
            gameObject.SetActive(false);
        }
    }
}
