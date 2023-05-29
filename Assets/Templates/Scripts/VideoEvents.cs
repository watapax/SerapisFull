using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;
public class VideoEvents : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public UnityEvent onVideoEnd;
    public bool esteVideo;
    public bool disableVideoOnEnd = false;
    public bool agregarEstrella = false;

    //bool videoEnd;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();  
        videoPlayer.loopPointReached += EndVideo;
    }

    void EndVideo(VideoPlayer vp)
    {
        if (vp == null & esteVideo == true)
        {
            vp = this.gameObject.GetComponent<VideoPlayer>();
        }
        if (disableVideoOnEnd == true)
        {
            this.gameObject.SetActive(false);
        }
        if (agregarEstrella == true && ManagerEscenas.Instance.sceneStatusArray[UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex] == false)
        {
            AgregarEstrella();
            ManagerEscenas.Instance.sceneStatusArray[UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex] = true;
        }
        onVideoEnd.Invoke();
    }

    void AgregarEstrella()
    {
        ManagerEscenas.Instance.AddStar();
    }



}
