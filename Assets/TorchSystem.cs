using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchSystem : MonoBehaviour
{
    [SerializeField] float rateOfLightDecay = 1f;
    [SerializeField] float rateOfAngleDecay = 1f;
    [SerializeField] float minAngle = 40f;
    [SerializeField] float maxAngle = 70f;
    [SerializeField] float fullCharge = 10f;

    Light torch;

    private void Start()
    {
        torch = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    public void Recharge(float charge)
    {
        torch.intensity += charge;
        var percentage = charge / fullCharge;
        var angleIncrease = percentage * (maxAngle - minAngle);
        if (angleIncrease > maxAngle) angleIncrease = maxAngle;
        torch.spotAngle += angleIncrease;
    }

    private void DecreaseLightIntensity()
    {
        torch.intensity -= rateOfLightDecay * Time.deltaTime;
    }

    private void DecreaseLightAngle()
    {
        if (torch.spotAngle > minAngle)
        {
            torch.spotAngle -= rateOfAngleDecay * Time.deltaTime;
        }
    }
}
