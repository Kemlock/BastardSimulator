using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        if (!isDead)
        { 
        BroadcastMessage("OnDamageTaken");

        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            isDead = true;
            GetComponent<Animator>().SetTrigger("Dead");
        }
    }
    }

}
