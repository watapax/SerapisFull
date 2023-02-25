using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class MenuSalir : MonoBehaviour
{
    public GameObject menu;
    bool toggleMenu;
    VideoPlayer[] videoPlayers;
    public bool acelerarVideos = false;

    //activar o desactivar fullscream
    public Toggle toggle;

    //subir o bajar volumen
    public Slider sliderVolumen;
    public float sliderVolumenValue;
    public Image imagenMute;

    //subir o bajar brillo app

    public Slider sliderBrillo;
    public float sliderBrilloValue;
    public Image panelBrillo;

    private void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
        //
        sliderVolumen.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = sliderVolumenValue;
        RevisarSiEstoyMuted();
        //
        sliderBrillo.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, sliderBrillo.value);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            toggleMenu = !toggleMenu;

        menu.SetActive(toggleMenu);
        if (toggleMenu)
        {
            PausarVideos();
        }
        else
        {
            ContinuarVideos();
        }
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.UpArrow))
        {
            if (acelerarVideos == false)
            {
                acelerarVideos = true;
            }
            else
            {
                acelerarVideos = false;
            }
        }
    }

    public void Salir()
    {
        Application.Quit();
    } 

    public void Quedarse()
    {
        toggleMenu = false;
    }
    void PausarVideos()
    {
        videoPlayers = FindObjectsOfType<VideoPlayer>();
        for (int i = 0; i < videoPlayers.Length; i++)
        {
            videoPlayers[i].playbackSpeed = 0;
        }
    }
    void ContinuarVideos()
    {
        videoPlayers = FindObjectsOfType<VideoPlayer>();
        for (int i = 0; i < videoPlayers.Length; i++)
        {
            if (!acelerarVideos)
            {
                videoPlayers[i].playbackSpeed = 1;
            }
            if (acelerarVideos)
            {
                videoPlayers[i].playbackSpeed = 10;
            }
        }
    }
    public void ActivarPantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    public void ChangeSliderVolumen(float valor)
    {
        sliderVolumenValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderVolumenValue);
        AudioListener.volume = sliderVolumenValue;
        RevisarSiEstoyMuted();
    }
    public void RevisarSiEstoyMuted()
    {
        if (sliderVolumenValue == 0)
        {
            imagenMute.enabled = true;
        }
        else
        {
            imagenMute.enabled = false;
        }
    }
    public void ChangeSliderBrillo(float valor)
    {
        sliderBrilloValue = valor;
        PlayerPrefs.SetFloat("brillo", sliderBrilloValue);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, sliderBrillo.value);
    }
}
