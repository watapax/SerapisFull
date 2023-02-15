using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FadeVideos : MonoBehaviour
{
    public float duracionFade;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void FadeOut(VideoPlayer video)
    {
        StartCoroutine(Fade(video));
    }
    public IEnumerator Fade(VideoPlayer video)
    {
        float t = 0;
        float alphaActual = video.targetCameraAlpha;
        float alphaDestino = 0;
        while (t < duracionFade)
        {
            t += Time.deltaTime;
            float p = t / duracionFade;
            video.targetCameraAlpha = Mathf.Lerp(alphaActual, alphaDestino, p);
            print(video.targetCameraAlpha);
            yield return null;
        }
    }
    public void FadeIn(VideoPlayer video)
    {
        StartCoroutine(FadeInCorrutina(video));
    }
    public IEnumerator FadeInCorrutina(VideoPlayer video)
    {
        float t = 0;
        float alphaActual = video.targetCameraAlpha;
        float alphaDestino = 1;
        while (t < duracionFade)
        {
            t += Time.deltaTime;
            float p = t / duracionFade;
            video.targetCameraAlpha = Mathf.Lerp(alphaActual, alphaDestino, p);
            print(video.targetCameraAlpha);
            yield return null;
        }
    }
}
