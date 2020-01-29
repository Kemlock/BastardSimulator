using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] GameObject impactVFX;
    [SerializeField] GameObject enemyImpactVFX;
    [SerializeField] ParticleSystem muzzleFX;
    [SerializeField] float damage = 10f;
    [SerializeField] float fireDelay = 1f;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;

    AudioSource gunFireAudioSource;
    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    private void Start()
    {
        gunFireAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && ammoSlot.GetCurrentAmmo(ammoType) > 0 && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        MuzzleFlash();
        PlayGunFireAudio();
        ProcessRayCast();
        ReduceAmmo();
        yield return new WaitForSeconds(fireDelay);
        canShoot = true;
    }

    private void ReduceAmmo()
    {
        ammoSlot.ReduceCurrentAmmo(ammoType);
    }

    private void PlayGunFireAudio()
    {
        gunFireAudioSource.Play();
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;
        bool isHit = Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);
        if (isHit)
        {
            
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null)
            {
                target.TakeDamage(damage);
                PlayImactEffect(hit, enemyImpactVFX);
            }
            else
            {
                PlayImactEffect(hit, impactVFX);
            }
        }
    }

    private void MuzzleFlash()
    {
        muzzleFX.Play();
    }

    private void PlayImactEffect(RaycastHit hit, GameObject effect)
    {
        GameObject impact = Instantiate(effect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
