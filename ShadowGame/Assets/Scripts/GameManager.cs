using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    
    [SerializeField] Slider timeSlider;
    public bool levelEnded = false;
    public Vector3 lightDirection = new Vector3(50, -30, 0);
    private GameObject directionalLight;
    public GameObject compass;
    [Range(6.0f, 18.0f)] public float time;
    
    public bool hasSavedPlayerPos = false;
    public Vector3 savedPlayerPos;
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
            //DontDestroyOnLoad(gameObject);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDestroy()
    {
        // Unsubscribe when destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find references again when a new scene is loaded
        if (scene.buildIndex != 0) // Skip for main menu
        {
            FindReferences();
        }
    }
    
    private void FindReferences()
    {
        // Find UI elements
        if (GameObject.Find("TimeSlider"))
        {
            timeSlider = GameObject.Find("TimeSlider").GetComponent<Slider>();
        }
        
        if (GameObject.Find("Compass"))
        {
            compass = GameObject.Find("Compass");
        }
        
        // Find light
        Light[] lights = FindObjectsOfType<Light>();
        foreach (Light light in lights)
        {
            if (light.type == LightType.Directional)
            {
                directionalLight = light.gameObject;
                break;
            }
        }
    }


    public void updateLightDirection(Vector3 deltaDir) 
    {
        lightDirection += deltaDir;
        //directionalLight.transform.rotation = Quaternion.Euler(lightDirection);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindReferences();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("k")) {
            if (BookManager.Instance != null)
            {
                BookManager.Instance.activate();
            }
        }
        
        // Only execute time-related code when in gameplay scene with UI elements
        if (timeSlider != null && compass != null && directionalLight != null)
        {
            // Time slider controls
            if (Input.GetKey("g"))
            {
                timeSlider.value -= 3 * Time.deltaTime;
            }
            if (Input.GetKey("h"))
            {
                timeSlider.value += 3 * Time.deltaTime;
            }
            time = timeSlider.value;
            lightDirection = timeToLightDirection(time);
            directionalLight.transform.rotation = Quaternion.Euler(lightDirection);
            compass.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -time * 10));
        }
    }

    private Vector3 timeToLightDirection(float time) 
    {
        float slope = (270 - 90) / (18 - 6);
        float azimuth = 90 + slope * (time - 6);
        double altitude = (-azimuth + 90) * (azimuth - 270) * (0.00679);
        return new Vector3((float)altitude, azimuth, 0);
    }

    public void changeLevel(string levelName) 
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void switchSceneButKeepPlayerPos(string levelName, Vector3 posToSave) 
    {
        hasSavedPlayerPos = true;
        savedPlayerPos = posToSave;
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
