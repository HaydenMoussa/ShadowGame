using UnityEngine;
using UnityEngine.UI;

public class ScenController : MonoBehaviour
{

    [SerializeField] private Button level2Button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        level2Button.interactable = GameData.Instance.level2Unlocked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
