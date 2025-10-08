using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class FootballMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    [SerializeField] private float projectileLife;
    [SerializeField] private float hazardTime;
    [SerializeField] private float goalTime;
    [SerializeField] private GameObject videoManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        videoManager = GameObject.Find("CrowdVideo");
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
            /*if (videoManager.player.isPlaying == false)
            {
                videoManager.player.Play();
                videoManager.Wait();
            }*/

            Debug.Log("WOW IT WORK 1");

            if (!videoManager.GetComponent<VideoManager>().GetComponent<VideoPlayer>().isPlaying) 
            {
                videoManager.GetComponent<VideoManager>().PlayVideo();
            }
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
            /*if (videoManager.player.isPlaying == false)
            {
                videoManager.player.Play();
                videoManager.Wait();
            }*/

            Debug.Log("WOW IT WORK 1");
            videoManager.GetComponent<VideoManager>().PlayVideo();

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
