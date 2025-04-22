using Unity.Mathematics;
using UnityEngine;

public class RotateAroundPoint : MonoBehaviour
{
    public float rotateSpeed = 5;
    public Vector3 rotateDim = new Vector3(1,1,1);

    public GameObject center;

    public float thetaAngle = 0;
    public float phiAngle = 0;

    public float rotDist = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
		// local thetaAngle = rotAngle1
		// local phiAngle = rotAngle2
		// local p = radius
		// local z = p * math.sin(math.rad(phiAngle)) * math.cos(math.rad(thetaAngle))
		// local y = p * math.sin(math.rad(phiAngle)) * math.sin(math.rad(thetaAngle))
		// local x = p * math.cos(math.rad(phiAngle))
		// local targetX = x + centerX
		// local targetY = y + centerY
		// local targetZ = z + centerZ
    // Update is called once per frame
    void Update()
    {
        thetaAngle += rotateSpeed * Time.deltaTime;
        phiAngle += rotateSpeed * Time.deltaTime;
        float zPos = math.sin(phiAngle) * math.cos(thetaAngle);
        float yPos = rotDist * math.sin(thetaAngle);
        float xPos = rotDist * math.cos(thetaAngle);
        Vector3 centerPos = center.transform.position;
        transform.position = new Vector3(xPos, yPos, 0) + centerPos;
    }
}
