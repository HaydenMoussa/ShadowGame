using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlay()
    {
        SceneManager.LoadScene(1);
        //player.SetVolume(.50f);
    }

    public void OnCredits()
    {
        SceneManager.LoadScene(4);
    }

    public void OnControls()
    {
        SceneManager.LoadScene(3);
    }

    public void MenuBack()
    {
        Debug.Log("Click back");
        SceneManager.LoadScene(0);
    }
}
