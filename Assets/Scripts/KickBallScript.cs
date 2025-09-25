using Unity.Mathematics;
using UnityEngine;

public class KickBallScript : MonoBehaviour
{
    float hCharge = 0; //hCharge will be in the form of rotation and bounce between -100 and 100.
    int hChargeDirection = 1;
    float halfMaxAngle = 45;

    float power = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hCharge += 1 * hChargeDirection;

        transform.rotation = Quaternion.Euler(0, 0, hCharge * halfMaxAngle);

        if (hCharge >= 100 || hCharge <= 0) hChargeDirection *= -1;
    }
}
