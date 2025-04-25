using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;

    public GameObject TimeSlider;
    public GameObject NoteBook;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (GameIsPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }


    public void Resume(){
        PauseMenuUI.SetActive(false);
        TimeSlider.SetActive(true);
        NoteBook.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Pause(){
        PauseMenuUI.SetActive(true);
        TimeSlider.SetActive(false);
        NoteBook.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Quit(){
        Time.timeScale = 1f;
        GameIsPaused = false;
    }


}
