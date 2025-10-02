using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Experimental.Video;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    private VideoPlayer player;
    private GameObject tvObject;
    [SerializeField] float Cliptime;
    void Awake()
    {
        VideoPlayer player = GetComponent<VideoPlayer>();
        VideoClip clip = player.clip;
        player.isLooping = false;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
        player.Pause();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player.isPlaying == false)
        {
            player.Play();
            Wait();
        } 
    }
}
