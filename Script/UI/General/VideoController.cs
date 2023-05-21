using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    private int currentVideoIndex = 0;//0 stand for start
    private bool isPause = false;
    public VideoPlayer video;
    public VideoClip[] videoClips;
    public int videoSize;
    public GameObject confirmMenu;
    

    public void setVideo(int index)
    {
        if (index >= videoSize) return;
        video.clip = videoClips[index];
    }
    
    public void playVideo()
    {
        video.Play();
    }
    
    public void pauseVideo()
    {
        video.Pause();
    }

    public void pauseAndPlayVideo()
    {
        if (!isPause)
        {
            
            pauseVideo();
            Time.timeScale = 0.0f;//TODO Show texts to let user know how to pause or resume it 
        }
        else
        {
            playVideo();//TODO Hide texts to let user know how to pause or resume it 
            Time.timeScale = 1.0f;
        }
    }

    //continuely play vidoe
    public void NextVideo1(int index)
    {
        if (index >= videoSize) 
        {
            return;
        }
        setVideo(index);
    }

    public void NextVideo2(int index)
    {
        if (index >= videoSize)
        {
            currentVideoIndex = 0;//TODO
        }
        else
            setVideo(index);
    }

    public void skipVideoConfirm()
    {
        video.Stop();
    }

    public void firstVideo()
    {
        setVideo(0);
        video.isLooping = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        video.clip = videoClips[currentVideoIndex];
        videoSize = videoClips.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            confirmMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            isPause = !isPause;
            pauseAndPlayVideo();
        }
    }
}
