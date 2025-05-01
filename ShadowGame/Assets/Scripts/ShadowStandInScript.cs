using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;

public class ShadowStandInScript : MonoBehaviour
{
    private Vector3 lightDir;

    [SerializeField] private Transform[] points;
    [SerializeField] private LineRenderer line;

    [SerializeField] private LayerMask layersToNotInteractWith;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lightDir = GameManager.Instance.lightDirection;
    }

    private void FixedUpdate()
    {
        drawLines();
    }

    private void drawLines() 
    {
        for (int i = 0;  i < points.Length; i++)
        {
            var point = points[i].transform.position;
            var raycastDirection = GameManager.Instance.lightDirection;
            raycastDirection = (Quaternion.Euler(raycastDirection) * Vector3.forward);

            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(point, raycastDirection, out hit, Mathf.Infinity, layersToNotInteractWith))
            {
                Debug.DrawRay(point, raycastDirection * 10000, Color.yellow);
                line.SetPosition(0, point);
                line.SetPosition(1, hit.point);
                //Debug.Log("Did Hit");
            }
        }
        
    }

}
