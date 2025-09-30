using UnityEngine;

public class FootballMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    private bool dissapearing = false;
    private int dissapearTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dissapearTimer <= 0 && dissapearing)
        {
            Destroy(gameObject);
        }
        else if (dissapearing)
        {
            dissapearTimer--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collider = collision.gameObject;

        dissapearing = true;
        dissapearTimer = 120;

        //some code to increase score or goal
    }
}
