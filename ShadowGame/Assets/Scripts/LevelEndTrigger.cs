using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerInputs>(out PlayerInputs pi)) 
        {
            GameManager.Instance.changeLevel("LevelSelect");
        }
    }
}
