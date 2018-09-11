using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    // Reference to https://n3k.ca/ for the creation of this asset

    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;

     Transform lookAt;
     Transform camTransform;
      public float distance = 10.0f;

    private float currentX = 0.0f;
    private float currentY = 45.0f;

    private void Start()
    {
        lookAt = GameObject.FindWithTag("Player").transform.Find("lookAt").transform;
        camTransform = transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        currentY += Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }

    public void setX(float x)
    {
        currentX += x;
    }
}
