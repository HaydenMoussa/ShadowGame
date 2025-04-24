using UnityEngine;

public class ScaleViewPlane : MonoBehaviour
{

    [SerializeField] Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //scale();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void scale() 
    {
        float pos = (cam.nearClipPlane + 0.01f);

        transform.position = cam.transform.position + cam.transform.forward * pos;

        //float xScale

        transform.localScale = new Vector3(h * cam.aspect, h, 0f);
    }*/
}
