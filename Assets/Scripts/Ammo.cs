using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AmmoType
{
    Pistol_Bullets,
    Rifle_Bullets,
    Shotgun_Cartridge
}

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public void PickupAmmo(AmmoType pickupType, int pickupAmount)
    {
        FindAmmoSlot(pickupType).ammoAmount += pickupAmount;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return FindAmmoSlot(ammoType).ammoAmount;
    }

    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        FindAmmoSlot(ammoType).ammoAmount--;
    }

    private AmmoSlot FindAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
