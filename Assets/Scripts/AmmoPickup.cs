﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] AmmoType ammoType;
    [SerializeField] int ammoAmmount = 20;
    [SerializeField] AudioClip audioClip;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Ammo>().PickupAmmo(ammoType, ammoAmmount);

            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);

            Destroy(gameObject);
        }
    }
}
