//using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ShadowCaster : MonoBehaviour
{

    Vector3 lightDirection;
    [SerializeField] Camera shadowCamera;
    //[SerializeField] Projector shadowProjector;
    [SerializeField] DecalProjector shadowProjector;
    [SerializeField] float distanceFromPoint;
    [SerializeField] Transform rotationPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lightDirection = GameManager.Instance.lightDirection;
    }

    private void FixedUpdate()
    {
        if(lightDirection.x % 360 < 170 && lightDirection.x % 360 > 10) 
        {
            shadowProjector.gameObject.SetActive(true);
            changeCameraAngle();
        }
        else 
        {
            shadowProjector.gameObject.SetActive(false);
        }
        
    }

    private void changeCameraAngle() 
    {
        shadowCamera.transform.rotation = Quaternion.Euler(lightDirection);
        shadowProjector.transform.rotation = Quaternion.Euler(lightDirection);
        //var angle = Mathf.Deg2Rad * lightDirection.x;
        //var tilt = Mathf.Deg2Rad * lightDirection.y;
        //var x = distanceFromPoint * Mathf.Cos(angle);
        //var y = distanceFromPoint * Mathf.Sin(angle) * Mathf.Sin(tilt);
        //var y = distanceFromPoint * Mathf.Sin(tilt);
        //var z = distanceFromPoint * Mathf.Sin(angle) * Mathf.Cos(tilt);
        //Vector3 targetPosition = new Vector3 (x, y, z);
        //Debug.Log(targetPosition);
        var direction = Quaternion.Euler(lightDirection);

        shadowCamera.transform.position = rotationPoint.position + -(direction * Vector3.forward) * distanceFromPoint;
        shadowProjector.transform.position = rotationPoint.position + -(direction * Vector3.forward) * distanceFromPoint;

        /*var raycastDirection = GameManager.Instance.lightDirection;
        raycastDirection = -(Quaternion.Euler(raycastDirection) * Vector3.forward);

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, raycastDirection, out hit, Mathf.Infinity, LayerMask.GetMask("ShadowCaster")))
        {
            Debug.DrawRay(transform.position, raycastDirection * 10000, Color.yellow);
            //Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, raycastDirection * 10000, Color.white);
            //Debug.Log("Did not Hit");
            //inShadow = false;
        }*/
    }
}
