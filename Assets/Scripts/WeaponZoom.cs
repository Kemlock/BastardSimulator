using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera zoomCam;
    [SerializeField] RigidbodyFirstPersonController rigidbodyFPC;
    [SerializeField] float zoomInLength = 30f;
    [SerializeField] float zoomOutLength = 60f;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = .5f;

    bool isZoomed = false;

    private void OnDisable()
    {
        ZoomOut();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isZoomed = !isZoomed;
        }

        if (isZoomed)
        {
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }
    }

    private void ZoomOut()
    {
        zoomCam.fieldOfView = zoomOutLength;
        rigidbodyFPC.mouseLook.XSensitivity = zoomOutSensitivity;
        rigidbodyFPC.mouseLook.YSensitivity = zoomOutSensitivity;
    }

    private void ZoomIn()
    {
        zoomCam.fieldOfView = zoomInLength;
        rigidbodyFPC.mouseLook.XSensitivity = zoomInSensitivity;
        rigidbodyFPC.mouseLook.YSensitivity = zoomInSensitivity;
    }
}
