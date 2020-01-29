using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;


    // Start is called before the first frame update
    void Start()
    {
        SetWeaponActive();
    }

    void Update()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();
        ProcessScrollWheel();

        if (previousWeapon != currentWeapon) SetWeaponActive();
    }

    private void ProcessScrollWheel()
    {
        float scrollDirection = Input.mouseScrollDelta.y;
        if (scrollDirection < 0)
        {
            currentWeapon++;
            if (currentWeapon == 3) currentWeapon = 0;
        }
        if(scrollDirection > 0)
        {
            currentWeapon--;
            if (currentWeapon == -1) currentWeapon = 2;
        }
    }

    private void ProcessKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
            {
            currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }
}
