using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // from tutorial https://www.youtube.com/watch?v=f473C43s8nE
    public Transform cameraPosition;
    private void Update()
    {
        transform.position = cameraPosition.position;
    }
}
