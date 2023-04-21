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

    public bool correcto = false;

    public ClipAudio[] clips;

    List<ClipAudio> clipsList = new List<ClipAudio>();

    int indiceActual;

    public UnityEvent onAudioCorrecto, onAudioIncorrecto;

    private int anterior = 10;
    private int anterior1 = 10;
    private int anterior2 = 10;
    private int anterior3 = 10;

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
        if (index == anterior || index == anterior1 || index == anterior2 || index == anterior3)
        {
            index = Random.Range(0, clipsList.Count);
        }
        else
        {
            audioSource.clip = clipsList[index].clip;
            indiceActual = clipsList[index].indice;
           // clipsList.RemoveAt(index);
           
            if (anterior == 10)
            {
                anterior = index;
            }
            else if (anterior1 == 10)
            {
                anterior1 = index;
            }
            else if (anterior2 == 10)
            {
                anterior2 = index;
            }
            else if (anterior3 == 10)
            {
                anterior3 = index;
            }
        }    
    }

    public void ChequearAudio(int indice)
    {
        if (indice == indiceActual)
        {
            onAudioCorrecto.Invoke();
            SelectAudioRandom();
            correcto = true;
            print("correcto  ");
        }
        else
            onAudioIncorrecto.Invoke();
        print("error");
    }

}
