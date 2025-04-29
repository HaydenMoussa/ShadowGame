using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SensitivityManager : MonoBehaviour
{
    [Header("Player Camera Reference")]
    public PlayerCam playerCamera;
    
    [Header("UI References")]
    public Slider sensitivitySlider;
    public TextMeshProUGUI sensitivityValueText;
    
    [Header("Sensitivity Range")]
    public float minSensitivity = 100f;
    public float maxSensitivity = 1000f;
    
    private const string SensitivityPrefKey = "MouseSensitivity";

    public GameObject PauseMenuUI;
    //private bool inOptions = false;
    public GameObject OptionsMenuUI;

    void Start()
    {
        // Validate references
        if (!playerCamera)
        {
            Debug.LogError("PlayerCam not assigned to SensitivityController!");
            return;
        }
        
        if (!sensitivitySlider)
        {
            Debug.LogError("Sensitivity slider not assigned to SensitivityController!");
            return;
        }
        
        // Configure slider
        sensitivitySlider.minValue = minSensitivity;
        sensitivitySlider.maxValue = maxSensitivity;
        
        // Load saved sensitivity if it exists, otherwise use current camera value
        float savedSensitivity;
        if (PlayerPrefs.HasKey(SensitivityPrefKey))
        {
            savedSensitivity = PlayerPrefs.GetFloat(SensitivityPrefKey);
            
            // Update camera with saved value
            playerCamera.SensX = savedSensitivity;
            playerCamera.SensY = savedSensitivity;
        }
        else
        {
            // Use current camera value
            savedSensitivity = playerCamera.SensX;
            PlayerPrefs.SetFloat(SensitivityPrefKey, savedSensitivity);
        }
        
        // Set slider to current value
        sensitivitySlider.value = savedSensitivity;
        
        // Register callback for slider changes
        sensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged);
        
        // Initial text update
        UpdateSensitivityText(savedSensitivity);
    }
    
    private void OnSensitivityChanged(float value)
    {
        // Update camera sensitivity
        playerCamera.SensX = value;
        playerCamera.SensY = value;
        
        // Save to PlayerPrefs
        PlayerPrefs.SetFloat(SensitivityPrefKey, value);
        
        // Update display text
        UpdateSensitivityText(value);
    }
    
    private void UpdateSensitivityText(float value)
    {
        if (sensitivityValueText != null)
        {
            sensitivityValueText.text = value.ToString("F0");
        }
    }

    public void UpdatePauseToOptions(){
        PauseMenuUI.SetActive(false);
        OptionsMenuUI.SetActive(true);
    }
    public void UpdatePauseToMain(){
        PauseMenuUI.SetActive(true);
        OptionsMenuUI.SetActive(false);

    }
}