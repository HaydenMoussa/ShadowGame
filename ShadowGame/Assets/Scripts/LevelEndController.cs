using UnityEngine;

public class LevelEndController : MonoBehaviour
{
    [SerializeField] Light levelPassedLight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.levelEnded)
        {
            levelEnded();
        }

    }

    void levelEnded() 
    {
        levelPassedLight.gameObject.SetActive(true);
    }
}
