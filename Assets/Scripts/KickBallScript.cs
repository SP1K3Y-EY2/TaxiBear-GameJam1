using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class KickBallScript : MonoBehaviour
{
    #region References
    private InputAction launchAction;
    [SerializeField] private GameObject football;
    private GameObject powerDisplay;
    #endregion

    #region Arrow Rotation
    private float hCharge = 0; //hCharge will be in the form of rotation and bounce between -100 and 100.
    private int hChargeDirection = 1;
    [SerializeField] private float hChargeRate;
    [SerializeField] private float halfAngle;
    #endregion

    #region Charge Kick
    private float power = 0;
    private float powerChargeDirection = 1;
    [SerializeField] private float powerChargeRate;
    [SerializeField] private float speed;
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        launchAction = InputSystem.actions.FindAction("Attack");
        launchAction.Enable();

        powerDisplay = GameObject.Find("PowerVisual");
    }

    // Update is called once per frame
    void Update()
    {
        if (launchAction.IsPressed())
        {
            power += powerChargeRate * powerChargeDirection;

            powerDisplay.transform.localScale = new Vector3(1f, 1f + (1f * power / 100f), 1f);
            powerDisplay.transform.localPosition = new Vector2(0, 0.21f + (0.5f * power / 100f));

            if (power <= 0 || power >= 100f) powerChargeDirection *= -1;
        }
        else
        {
            if (power > 0) LaunchBall();

            power = 0;
            powerChargeDirection = 1;

            powerDisplay.transform.localScale = new Vector3(1f, 1f, 1f);
            powerDisplay.transform.localPosition = new Vector2(0, 0.21f);

            hCharge += hChargeRate * hChargeDirection;

            transform.rotation = Quaternion.Euler(0, 0, hCharge / 100f * halfAngle);

            if (hCharge <= -100f || hCharge >= 100f) hChargeDirection *= -1;
        }
    }

    private void LaunchBall()
    {
        Vector2 ballVelocity = Vector2.zero;
        float velocityMod = 0.25f + (power / 100f - 0.25f);

        float angle = (90f + transform.eulerAngles.z) * Mathf.Deg2Rad;

        GameObject launchedBall = Instantiate(football, transform.position, transform.rotation);

        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        launchedBall.GetComponent<Rigidbody2D>().linearVelocity = direction * speed * velocityMod;
    }
}
