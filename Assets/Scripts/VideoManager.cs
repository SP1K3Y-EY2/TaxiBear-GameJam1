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
    }

    public void PlayVideo(float time)
    {
        Debug.Log("WOW IT WORK 2");
        StartCoroutine(Wait(time));
    }

   
}
