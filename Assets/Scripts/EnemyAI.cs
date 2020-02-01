using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    
    [SerializeField] float detectionRange = 15f;
    [SerializeField] float turnSpeed = 5f;

    Transform target;
    EnemyHealth enemyHealth;
    bool IsProvoked = false;
    
    
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity; //Otherwise will chase by default

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
    }


    void Update()
    {
        if (enemyHealth.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        else
        {
            distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (distanceToTarget <= detectionRange || IsProvoked)
            {
                IsProvoked = true;
                EngageTarget();
            }
        }
    }

    public void OnDamageTaken()
    {
        IsProvoked = true;
    }

    void EngageTarget()
    {
        FaceTarget();

        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack",true);
    }

    void ChaseTarget()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Attack", false);
        anim.SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 1F);
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
