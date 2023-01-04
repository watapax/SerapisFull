using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class ClipAudio
{
    public AudioClip clip;
    public int indice;
}

public class AudiosRandom : MonoBehaviour
{
    public AudioSource audioSource;

    public ClipAudio[] clips;

    List<ClipAudio> clipsList = new List<ClipAudio>();

    int indiceActual;

    public UnityEvent onAudioCorrecto, onAudioIncorrecto;

    private void Start()
    {
        for (int i = 0; i < clips.Length; i++)
        {
            clipsList.Add(clips[i]);
        }
        SelectAudioRandom();

  
    }

    public void SelectAudioRandom()
    {
        int index = Random.Range(0, clipsList.Count);

        audioSource.clip= clipsList[index].clip;
        indiceActual = clipsList[index].indice;
        clipsList.RemoveAt(index);
    }

    public void ChequearAudio(int indice)
    {
        if (indice == indiceActual)
        {
            onAudioCorrecto.Invoke();
            SelectAudioRandom();
        }
        else
            onAudioIncorrecto.Invoke();
    }

}
