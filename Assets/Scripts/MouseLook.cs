using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 1.5f;
    public float smoothing = 1.5f;


    private float xMousePos;
    private float smoothedMousePos;

    private float rotationY = 0;
    public float lookSpeed = 2f;
    public float lookYLimit = 45f;

    private float currentLookPos;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        GetInput();
        ModifyInput();
        MovePlayer();
    }

    void GetInput()
    {
        rotationY += -Input.GetAxis("Mouse Y") * lookSpeed;
        xMousePos = Input.GetAxisRaw("Mouse X");
    }

    void ModifyInput()
    {
        rotationY = Mathf.Clamp(rotationY, -lookYLimit, lookYLimit);
        xMousePos *= sensitivity * smoothing;
        smoothedMousePos = Mathf.Lerp(smoothedMousePos, xMousePos, 1f / smoothing);
    }

    void MovePlayer()
    {
        currentLookPos += smoothedMousePos;
        //transform.localRotation = Quaternion.Euler(rotationY, 0, 0);
        //transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        //transform.rotation = Quaternion.AngleAxis(rotationY, transform.forward);
        transform.localRotation = Quaternion.AngleAxis(currentLookPos, transform.up);
    }
}
