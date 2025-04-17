using UnityEngine;

public class ShadowDetection : MonoBehaviour
{

    private Vector3 raycastDirection;
    [SerializeField] private GameObject pointHolder;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

        Debug.Log("Hit is " + inShadow);
        if (inShadow) 
        {
            GameManager.Instance.levelEnded = true;
        }

    }
}
