using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    float targetRotation = 0;
    float speed = 0.005f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.levelEnded) 
        {
            Quaternion rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, targetRotation, 0)), speed);
            transform.rotation = rotation;
        }
    }
}
