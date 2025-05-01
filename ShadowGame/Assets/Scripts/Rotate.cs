using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotateSpeed = 5;

    public Vector3 rotateVals = new Vector3(0, 0,1);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotAmount  = rotateVals * rotateSpeed * Time.deltaTime;
        transform.Rotate(rotAmount);
    }
}
