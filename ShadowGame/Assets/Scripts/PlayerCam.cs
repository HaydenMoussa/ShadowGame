using System;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    //From https://www.youtube.com/watch?v=f473C43s8nE tutorial
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static PlayerCam Instance { get; private set;}
    public float SensX = 400f;
    public float SensY = 400f;

    public bool movement_active = true;

    // Keys for storing sensitivity in PlayerPrefs
    private const string SensXPrefKey = "SensitivityX";
    private const string SensYPrefKey = "SensitivityY";
    public Transform orientation;
    float xRotation;
    float yRotation;

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // Load saved sensitivity settings if they exist
        if (PlayerPrefs.HasKey(SensXPrefKey))
        {
            SensX = PlayerPrefs.GetFloat(SensXPrefKey);
            SensY = PlayerPrefs.GetFloat(SensYPrefKey);
        }
        else
        {
            // Save default values
            PlayerPrefs.SetFloat(SensXPrefKey, SensX);
            PlayerPrefs.SetFloat(SensYPrefKey, SensY);
        }
    }

    private void Update()
    {
        if (Time.timeScale != 0 && movement_active)
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
     // Method to update sensitivity from settings menu
    public void UpdateSensitivity(float sensitivity)
    {
        SensX = sensitivity;
        SensY = sensitivity;
        
        // Save to PlayerPrefs
        PlayerPrefs.SetFloat(SensXPrefKey, sensitivity);
        PlayerPrefs.SetFloat(SensYPrefKey, sensitivity);
    }
    
    // Alternative method if you want separate X and Y sensitivity
    public void UpdateSensitivityXY(float sensitivityX, float sensitivityY)
    {
        SensX = sensitivityX;
        SensY = sensitivityY;
        
        // Save to PlayerPrefs
        PlayerPrefs.SetFloat(SensXPrefKey, sensitivityX);
        PlayerPrefs.SetFloat(SensYPrefKey, sensitivityY);
    }
}
