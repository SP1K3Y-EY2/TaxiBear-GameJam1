using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Experimental.Video;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    private VideoPlayer player;
    private float Cliptime;
    private GameObject tvObject;
    private bool isPlaying = false;
  void Awake()
    {
        VideoPlayer player = GetComponent<VideoPlayer>();
        VideoClip clip = player.clip;
        player.isLooping = false;
    }


   IEnumerator Wait()
    {
        yield return new WaitForSeconds(Cliptime);
        player.Pause();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPlaying = false)
        {





        } }

    private void OnEnable(tvObject)
    {
        isPlaying = true;
        player.Play();
        Wait();

    }
}
