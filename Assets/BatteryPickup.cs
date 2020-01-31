using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float charge = 10f;
    [SerializeField] AudioClip audioClip;

    //AudioSource newAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponentInChildren<TorchSystem>().Recharge(charge);

            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);

            Destroy(gameObject);
        }
    }
}
