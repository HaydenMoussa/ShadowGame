using System;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    //From https://www.youtube.com/watch?v=f473C43s8nE tutorial
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float SensX;
    public float SensY;

    public Transform orientation;
    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //getting mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * SensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * SensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f,40f);

        //Rotating the cam
        transform.rotation = Quaternion.Euler(xRotation, yRotation,0);
        orientation.rotation = Quaternion.Euler(0,yRotation,0);
    }
}
