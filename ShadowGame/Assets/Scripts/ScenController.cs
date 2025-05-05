using UnityEngine;
using UnityEngine.UI;

public class ScenController : MonoBehaviour
{

    [SerializeField] private Button level2Button;
    [SerializeField] private bool mouseLocked;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        level2Button.interactable = GameData.Instance.level2Unlocked;
        if (mouseLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else 
        {
            Cursor.lockState = CursorLockMode.None;
        }
        
        Cursor.visible = !mouseLocked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
