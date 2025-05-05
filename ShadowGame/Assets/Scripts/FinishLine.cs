using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
        [SerializeField] private string newGameLevel = "";
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player")){
            Debug.Log(collision.gameObject.name + " : " + gameObject.name + " : " + Time.time);
            //GameData.Instance.level2Unlocked = true;
            SceneManager.LoadScene(newGameLevel);
            
        }
        
    }

}
