using UnityEngine;

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

    //Light Stuff
    public Vector3 lightDirection = new Vector3(50, -30, 0);
    private GameObject directionalLight;

    public void updateLightDirection(Vector3 deltaDir) 
    {
        lightDirection += deltaDir;
        directionalLight.transform.rotation = Quaternion.Euler(lightDirection);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        directionalLight = FindAnyObjectByType<Light>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        updateLightDirection(new Vector3(0, 0, 0));
    }
}
