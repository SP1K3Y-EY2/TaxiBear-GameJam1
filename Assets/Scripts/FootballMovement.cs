using System.Collections;
using UnityEngine;

public class FootballMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    [SerializeField] private float projectileLife;
    [SerializeField] private float hazardTime;
    [SerializeField] private float goalTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Dissapear(projectileLife));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collider = collision.gameObject;

        if (collider.CompareTag("Goal"))
        {
            StartCoroutine(Dissapear(goalTime));
        }
        else if (collider.CompareTag("Hazard"))
        {
            StartCoroutine(Dissapear(hazardTime));
        }

        //some code to increase score or goal
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider = collision.gameObject;

        if (collider.CompareTag("Goal"))
        {
            StartCoroutine(Dissapear(goalTime));
        }
        else if (collider.CompareTag("Hazard"))
        {
            StartCoroutine(Dissapear(hazardTime));
        }

        //some code to increase score or goal
    }

    IEnumerator Dissapear(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
