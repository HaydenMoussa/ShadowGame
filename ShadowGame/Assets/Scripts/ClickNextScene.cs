using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ClickNextScene : MonoBehaviour
{
        [SerializeField] private string newGameLevel = "";

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene(newGameLevel);
        }
        }

        }
