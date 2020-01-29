using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100;

    public void TakeDamage(float damage)
    {
        print("hit");
        health -= damage;
        if(health <=0 )
        {
            GetComponent<DeathHandler>().Death();
        }
    }

}
