using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject textPanel;
    public TextMeshProUGUI dialogueTextBox;
    
    public GameObject tipPanel;
    public TextMeshProUGUI tipText;
    
    public string[] startDialogue;
    public string[] areaDialogue;
    public string[] endDialogue;
    
    public string startTip;
    public string areaTip;
    
    public float textSpeed = 0.05f;
    public float tipTime = 5f;
    
    private int lineIndex = 0;
    private bool isWriting = false;
    public string[] currentLines;
    private string currentTip;
    private int dialogueType = 0;
    
    private bool isDialogueActive = false;
    private float previousTimeScale;
    
    void Start()
    {
        textPanel.SetActive(false);
        tipPanel.SetActive(false);
        Invoke("ShowFirstDialogue", 1f);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isDialogueActive)
        {
            if (isWriting)
            {
                StopAllCoroutines();
                dialogueTextBox.text = currentLines[lineIndex];
                isWriting = false;
            }
            else
            {
                lineIndex++;
                
                if (lineIndex < currentLines.Length)
                {
                    StartCoroutine(TypeText(currentLines[lineIndex]));
                }
                else
                {
                    EndDialogue();
                }
            }
        }
    }
    
    void ShowFirstDialogue()
    {
        currentLines = startDialogue;
        currentTip = startTip;
        dialogueType = 0;
        ShowDialogue();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            currentLines = areaDialogue;
            currentTip = areaTip;
            dialogueType = 1;
            ShowDialogue();
        }
    }
    
    public void ShowDialogue()
    {
        PauseGame();
        
        textPanel.SetActive(true);
        isDialogueActive = true;
        lineIndex = 0;
        StartCoroutine(TypeText(currentLines[lineIndex]));
    }
    
    void EndDialogue()
    {
        textPanel.SetActive(false);
        isDialogueActive = false;
        
        UnpauseGame();
        
        if (dialogueType == 0 || dialogueType == 1)
        {
            ShowTip();
        }
    }
    public void ShowGoalDialogue()
    {
        currentLines = endDialogue;
        currentTip = ""; 
        dialogueType = 2; 
        ShowDialogue();
    }

    void ShowTip()
    {
        tipPanel.SetActive(true);
        tipText.text = currentTip;
        
        // Hide tip after tipTime seconds
        Invoke("HideTip", tipTime);
    }
    
    void HideTip()
    {
        tipPanel.SetActive(false);
    }
    
    void PauseGame()
    {
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;
    }
    
    void UnpauseGame()
    {
        Time.timeScale = previousTimeScale;
    }
    
    IEnumerator TypeText(string line)
    {
        isWriting = true;
        dialogueTextBox.text = "";
        
        foreach (char c in line.ToCharArray())
        {
            dialogueTextBox.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
        
        isWriting = false;
    }
}

