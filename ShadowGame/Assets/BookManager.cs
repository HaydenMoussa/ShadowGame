using UnityEngine;

public class BookManager : MonoBehaviour
{
    public static BookManager Instance { get; private set;}
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate() {
        
    } 
}
