using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FuncionesAudio : MonoBehaviour
{
    public UnityEvent onEndAudioPlay, onStartAudioPlay;
    public AudioSource audioSource;
    public void SetClip(AudioClip _clip)
    {
        audioSource.clip = _clip;
    }

    public void PlayAudio(AudioClip _clip)
    {
        audioSource.PlayOneShot(_clip);
    }

    public void PlayClip(AudioClip _clip)
    {
        audioSource.clip = _clip;
        audioSource.Play();
        onStartAudioPlay.Invoke();
        StartCoroutine(EndAudioCheck());

    }

    IEnumerator EndAudioCheck()
    {
 
        while(audioSource.isPlaying)
        {
            yield return null;
        }

        onEndAudioPlay.Invoke();
    }
}
