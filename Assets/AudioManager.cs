using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance { get; private set; }
    [Range(0, 1), Tooltip("al llegar a este volumen se detendra la suma")]
    public float maxVol;
    [Range(0,1), Tooltip("al llegar a este volumen se detendra la resta y es el valor con el que inicia un audio")]
    public float minVol;

    public AudioSource[] audioSources;

    public bool fadeIn = true;

    public float duracionFade = 2f;

    ManagerEscenas managerEscenas;

    // Start is called before the first frame update

    private void Awake()
    {
        audioSources = FindObjectsOfType<AudioSource>();
        managerEscenas = FindObjectOfType<ManagerEscenas>();
        managerEscenas.audioManager = this;
    }
    void Start()
    {      
        if (Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(this.gameObject);
        }
        if (fadeIn == true)
        {
            managerEscenas = FindObjectOfType<ManagerEscenas>();
            AudioIn();
        }
    }
    private void Update()
    {
        audioSources = FindObjectsOfType<AudioSource>();
    }
    public void AudioOut()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            // StartCoroutine(FadeOutAudio(audioSources[i]));
            StartCoroutine(FadeAudio(false,audioSources[i]));
        }
    }
    public void AudioIn()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].volume = minVol;
           // StartCoroutine(FadeInAudio(audioSources[i]));
            StartCoroutine(FadeAudio(true, audioSources[i]));
        }
    }
    public IEnumerator FadeAudio(bool _state, AudioSource audio)
    {
        float volumenActual = audio.volume;
        float volumenDestino = _state == true ? maxVol : minVol;
        float t = 0;
        while (t < duracionFade)
        {
            t += Time.deltaTime;
            float p = t / duracionFade;
            audio.volume = Mathf.Lerp(volumenActual, volumenDestino, p);
            yield return null;
        }
    }
}
