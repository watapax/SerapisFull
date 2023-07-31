using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OnEndAudio : MonoBehaviour
{
    public UnityEvent onEndAudio;

    public AudioSource audioSource;
    public bool agregarEstrella = false;
    public bool PlayOnAwake = true;

    IEnumerator Start()
    {
        audioSource.Play();
        yield return new WaitUntil(() => !audioSource.isPlaying);
        onEndAudio.Invoke();
        if (agregarEstrella == true && ManagerEscenas.Instance.sceneStatusArray[UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex] == false)
        {
            AgregarEstrella();
            ManagerEscenas.Instance.sceneStatusArray[UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex] = true;
        }
    }
    void AgregarEstrella()
    {
        ManagerEscenas.Instance.AddStar();
    }

}
