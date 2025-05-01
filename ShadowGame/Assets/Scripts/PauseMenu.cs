using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;

    public GameObject TimeSlider;
    public GameObject NoteBook;
    

    public GameObject ClockUI;

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
        if (PauseMenuUI != null)
            PauseMenuUI.SetActive(false);
        
        if (TimeSlider != null)
            TimeSlider.SetActive(true);
        
        if (ClockUI  != null)
            ClockUI.SetActive(true);
        
        if (NoteBook != null)
            NoteBook.SetActive(true);
            
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Pause(){
        if (PauseMenuUI != null)
            PauseMenuUI.SetActive(true);
        
        if (TimeSlider != null)
            TimeSlider.SetActive(false);
        if (ClockUI  != null)
            ClockUI.SetActive(false);
        
        if (NoteBook != null)
            NoteBook.SetActive(false);
            
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Quit(){
        if (PauseMenuUI != null)
            PauseMenuUI.SetActive(false);
        
        if (TimeSlider != null)
            TimeSlider.SetActive(true);
        
        if (NoteBook != null)
            NoteBook.SetActive(true);
            
        GameIsPaused = false;
        
        // Reset time scale
        Time.timeScale = 1f;
        
        // Reset cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        // Load main menu
        SceneManager.LoadScene(0);
    }


}
