using UnityEngine;

public class PickupGoal : MonoBehaviour
{
    public DialogueManager dialogueScript;
    private bool pickedUp = false;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !pickedUp)
        {
            pickedUp = true;
            
            //GetComponent<MeshRenderer>().enabled = false;
            
            dialogueScript.currentLines = dialogueScript.endDialogue;
            dialogueScript.ShowDialogue();

            //GameData.Instance.level2Unlocked = true;

            //GameManager.Instance.changeLevel("LevelSelect");
        }
    }
}