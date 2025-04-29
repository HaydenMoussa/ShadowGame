using UnityEngine;

public class ClockManager : MonoBehaviour
{
    public GameObject player;
    
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player.transform.position);
        }
        else
        {
            // Try to find the player again if it's missing
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
}
