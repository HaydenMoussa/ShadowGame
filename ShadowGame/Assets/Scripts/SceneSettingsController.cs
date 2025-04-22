using UnityEngine;

public class SceneSettingsController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScene() 
    {
        GameManager.Instance.changeLevel("MainMenu");
    }
}
