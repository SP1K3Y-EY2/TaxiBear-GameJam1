using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Experimental.Video;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    private VideoPlayer player;
    //private GameObject tvObject;
    [SerializeField] float Cliptime;
    private int videoProgress = 0;

    void Awake()
    {
        VideoPlayer player = gameObject.GetComponent<VideoPlayer>();
        VideoClip clip = player.clip;
        player.isLooping = false;
    }
    IEnumerator Wait(float time)
    {
        gameObject.GetComponent<VideoPlayer>().Play();
        //player.Play();
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<VideoPlayer>().Pause();
        //player.Pause();

        videoProgress++;

        if (videoProgress > 3) videoProgress = 0;
    }

    public void PlayVideo()
    {
        float time = 0;

        switch (videoProgress) //25 second video
        {
            case 0:
                time = 6;
                break;
            case 1:
                time = 6;
                break;
            case 2:
                time = 6;
                break;
            case 3:
                time = 7;
                break;
            default:
                time = 0;
                break;
        }

        Debug.Log("WOW IT WORK 2");
        StartCoroutine(Wait(time));
    }

   
}
