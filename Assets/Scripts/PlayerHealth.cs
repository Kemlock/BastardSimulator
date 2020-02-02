using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] Canvas damageCanvas;

    public void TakeDamage(float damage)
    {
        StartCoroutine(ShowDamage());
        health -= damage;
        if(health <=0 )
        {
            GetComponent<DeathHandler>().Death();
        }
    }

    IEnumerator ShowDamage()
    {
        damageCanvas.enabled = true;

        yield return new WaitForSeconds(0.3f);

        damageCanvas.enabled = false;
    }
}
