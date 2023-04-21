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
        StartCoroutine(EndAudioCheckCorrecto());
        StartCoroutine(EndAudioCheckIncorrecto());
    }

    public void PlayFromStart()
    {
        audioSource.Stop();
        audioSource.Play();
    }

    IEnumerator EndAudioCheckIncorrecto()
    {
 
        while(audioSource.isPlaying)
        {
            yield return null;
        }

        onEndAudioPlay.Invoke();
    }
    IEnumerator EndAudioCheckCorrecto()
    {

        while (audioSource.isPlaying)
        {
            yield return null;
        }

        onEndAudioPlay.Invoke();
    }
}
