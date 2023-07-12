using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;
public class SecuenciaVideos : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    public UnityEvent onEndSequence;
    public float delayTime;
    //public string[] urlVideos;
    public VideoClip[] clips;
    int index = 0;
    public bool agregarEstrella = false;
    private void Start()
    {
        videoPlayer.prepareCompleted += Prepared;
    }

    private void OnDisable()
    {
        videoPlayer.prepareCompleted -= Prepared;
    }

    public void NextVideo()
    {
        if (index == clips.Length)
        {
            onEndSequence.Invoke();
            return;
        }
        videoPlayer.Stop();
        videoPlayer.clip = null;
        videoPlayer.clip = clips[index];
        //videoPlayer.url = urlVideos[index];
        videoPlayer.Prepare();

        index++;
    }

    void Prepared(VideoPlayer vPlayer)
    {
        Debug.Log("End reached!");
        vPlayer.Play();
        if(delayTime > 0)
        {
            StartCoroutine(DelayVideo());
        }
    }

    IEnumerator DelayVideo()
    {
        yield return new WaitForEndOfFrame();
        videoPlayer.Pause();
        yield return new WaitForSeconds(delayTime);
        videoPlayer.Play();
    }

    public void CheckFinalVideo()
    {
        if (index == clips.Length)
        {
            onEndSequence.Invoke();
            if (agregarEstrella == true && ManagerEscenas.Instance.sceneStatusArray[UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex] == false)
            {
                AgregarEstrella();
                ManagerEscenas.Instance.sceneStatusArray[UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex] = true;
            }
            return;
        }
    }
    void AgregarEstrella()
    {
        ManagerEscenas.Instance.AddStar();
    }
}
