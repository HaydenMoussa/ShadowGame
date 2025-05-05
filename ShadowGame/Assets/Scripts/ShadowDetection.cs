using System.Runtime.CompilerServices;
using UnityEngine;

public class ShadowDetection : MonoBehaviour
{

    private Vector3 raycastDirection;
    [SerializeField] private GameObject pointHolder;

    [SerializeField] private bool GemStoneRequired = false;

    [SerializeField] private float timeTillDoorOpens = 2f;

    [SerializeField] private Color lightColor = Color.red;

    [SerializeField] private GameObject levelCompleteSoundEffect;

    private Light encouragementLight;

    private bool doorOpened = false;

    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        encouragementLight = GetComponent<Light>();
        if (!encouragementLight) 
        {
            encouragementLight = gameObject.AddComponent<Light>();
            encouragementLight.intensity = 0;
            encouragementLight.type = LightType.Point;
            encouragementLight.color = lightColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //pointHolder = gameObject.transform.GetChild(0).gameObject;
    }

    private void FixedUpdate()
    {
        checkIfInShadow();
    }

    void checkIfInShadow()
    {
        raycastDirection = GameManager.Instance.lightDirection;
        raycastDirection = -(Quaternion.Euler(raycastDirection) * Vector3.forward);

        bool inShadow = true;

        for (int i = 0; i < pointHolder.transform.childCount; i++) 
        {
            var point = pointHolder.transform.GetChild(i).transform.position;

            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (GemStoneRequired)
            {
                if (Physics.Raycast(point, raycastDirection, out hit, Mathf.Infinity, LayerMask.GetMask("Gemstone")))
                {
                    Debug.DrawRay(point, raycastDirection * 10000, Color.yellow);
                    //Debug.Log("Did Hit");
                }
                else
                {
                    Debug.DrawRay(point, raycastDirection * 10000, Color.white);
                    //Debug.Log("Did not Hit");
                    inShadow = false;
                }
            }
            else 
            {
                if (Physics.Raycast(point, raycastDirection, out hit, Mathf.Infinity, LayerMask.GetMask("ShadowCaster")))
                {
                    Debug.DrawRay(point, raycastDirection * 10000, Color.yellow);
                    //Debug.Log("Did Hit");
                }
                else
                {
                    
                    Debug.DrawRay(point, raycastDirection * 10000, Color.white);
                    //Debug.Log("Did not Hit");
                    inShadow = false;
                }
            }
            
        }

        Debug.Log("Hit is " + inShadow);

        if (inShadow)
        {
            encouragementLight.intensity = 1;
            if (timer > timeTillDoorOpens)
            {
                if (!doorOpened) 
                {
                    GameObject go = Instantiate(levelCompleteSoundEffect);
                    Destroy(go, 1); ;
                    GameManager.Instance.levelEnded = true;
                    doorOpened = true;
                }   
            }
            else 
            {
                timer += Time.deltaTime;
            }
            
        }
        else 
        {
            encouragementLight.intensity = 0;
            timer = 0;
        }
    }
}
