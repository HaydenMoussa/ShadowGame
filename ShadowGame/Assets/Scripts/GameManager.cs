using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [SerializeField] Slider timeSlider;

    public bool levelEnded = false;

    //Light Stuff
    public Vector3 lightDirection = new Vector3(50, -30, 0);
    private GameObject directionalLight;

    [Range(6.0f, 18.0f)] public float time;

    public void updateLightDirection(Vector3 deltaDir) 
    {
        lightDirection += deltaDir;
        //directionalLight.transform.rotation = Quaternion.Euler(lightDirection);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        directionalLight = FindAnyObjectByType<Light>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //updateLightDirection(new Vector3(0, 0, 0));
        if (timeSlider) 
        {
            time = timeSlider.value;
        }
        lightDirection = timeToLightDirection(time);
        directionalLight.transform.rotation = Quaternion.Euler(lightDirection);
    }

    private Vector3 timeToLightDirection(float time) 
    {
        float slope = (270 - 90) / (18 - 6);
        float azimuth = 90 + slope * (time - 6);
        double altitude = (-azimuth + 90) * (azimuth - 270) * (0.00679);
        return new Vector3((float)altitude, azimuth, 0);
    }
}
