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
    public float maxSensitivity = 200f;
    
    private const string SensXPrefKey = "SensitivityX";
    private const string SensYPrefKey = "SensitivityY";

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
        float currentSensitivity;
        if (PlayerPrefs.HasKey(SensXPrefKey))
        {
            currentSensitivity = PlayerPrefs.GetFloat(SensXPrefKey);
            Debug.Log("Loaded sensitivity from PlayerPrefs: " + currentSensitivity);
        }
        else
        {
            // Use current camera value if no saved preference
            currentSensitivity = playerCamera.SensX;
            Debug.Log("Using default camera sensitivity: " + currentSensitivity);
            
            // Save it to PlayerPrefs
            PlayerPrefs.SetFloat(SensXPrefKey, currentSensitivity);
            PlayerPrefs.SetFloat(SensYPrefKey, currentSensitivity);
        }
        
        // Set slider to current value
        sensitivitySlider.value = currentSensitivity;
        
        // Register callback for slider changes
        sensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged);
        
        // Initial text update
        UpdateSensitivityText(currentSensitivity);
    }
    
    private void OnSensitivityChanged(float value)
    {
        // Update camera sensitivity using PlayerCam's method
        playerCamera.UpdateSensitivity(value);
        
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