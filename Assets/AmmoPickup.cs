using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] AmmoType ammoType;
    [SerializeField] int ammoAmmount = 20;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            other.GetComponent<Ammo>().PickupAmmo(ammoType, ammoAmmount);
            Destroy(gameObject);
        }
    }
}
