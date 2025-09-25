using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class KickBallScript : MonoBehaviour
{
    InputAction launchAction;

    float hCharge = 0; //hCharge will be in the form of rotation and bounce between -100 and 100.
    int hChargeDirection = 1;
    float hChargeRate = 0.2f;
    float halfMaxAngle = 45f;

    float power = 0;
    int powerChargeDirection = 1;
    float powerChargeRate = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        launchAction = InputSystem.actions.FindAction("Attack");
        launchAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (launchAction.IsPressed())
        {
            power += powerChargeRate * powerChargeDirection;

            if (power <= 0 || power >= 100) powerChargeDirection *= -1;
        }
        else
        {
            hCharge += hChargeRate * hChargeDirection;

            transform.rotation = Quaternion.Euler(0, 0, (hCharge / 100f) * halfMaxAngle);

            if (hCharge <= -100 || hCharge >= 100) hChargeDirection *= -1;
        }
    }
}
