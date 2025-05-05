using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    GameObject self;
    AudioSource audio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                self = gameObject;
        DontDestroyOnLoad(self);
        audio = self.GetComponent<AudioSource>();
            }
            else
            {
                Destroy(gameObject);
            }
        }

    public static MusicPlayer Instance { get; private set; }
    
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume(float volume) {
        audio.volume = volume;
    }

}
