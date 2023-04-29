using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

public class MenuSalir : MonoBehaviour
{
    public GameObject menu;
    bool toggleMenu;
    [SerializeField]
    VideoPlayer[] videoPlayers;
    public bool acelerarVideos = false;
    public bool blockearMouse = false;

    //activar o desactivar fullscream
    public Toggle toggle;
    public bool pantallaCompleta = true;

    //subir o bajar volumen
    public Slider sliderVolumen;
    public float sliderVolumenValue;
    public Image imagenMute;

    //subir o bajar brillo app

    public Slider sliderBrillo;
    public float sliderBrilloValue;
    public Image panelBrillo;

    //
   // public PlayerCamera playerCamera;
    //calidad imagen
    public TMP_Dropdown dropdown;
    public int calidad;

    //cambiarResolucion
    public TMP_Dropdown resolucionesDropdown;
    Resolution[] resoluciones;

    public ActivarMouse activarMouse;//si hay blockeamos y ocultamos el mouse lo usaremos en escenas que el conejo se pueda mover si no hay se asume que es un minijuego que necesitamos el mouse
    private void Start()
    {
        activarMouse = FindObjectOfType<ActivarMouse>();
        if (activarMouse != null)
        {
            blockearMouse = true;
        }
        else
        {
            blockearMouse = false;
        }
        RevisarResolucion();
        //playerCamera = FindObjectOfType<PlayerCamera>();
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
        //sonido
        sliderVolumen.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = sliderVolumenValue;
        RevisarSiEstoyMuted();
        //brillo
        sliderBrillo.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, sliderBrillo.value);
        //calidad
        calidad = PlayerPrefs.GetInt("numeroDeCalidad", 3);
        dropdown.value = calidad;
        AjustarCalidad();
    }
    private void OnLevelWasLoaded()
    {
        activarMouse = FindObjectOfType<ActivarMouse>();
        if (activarMouse != null)
        {
            blockearMouse = true;
        }
        else
        {
            blockearMouse = false;
        }
        for (int i = 0; i < videoPlayers.Length; i++)
        {
            videoPlayers = FindObjectsOfType<VideoPlayer>();
        }
        
        //playerCamera = FindObjectOfType<PlayerCamera>();
    }
    private void Update()
    {
        if (videoPlayers != null)
        {
            for (int i = 0; i < videoPlayers.Length; i++)
            {
                videoPlayers[i].SetDirectAudioVolume(0, sliderVolumenValue);
            }
        }       
        OcultarMouse();
        //print(Cursor.visible.ToString());
        print(Cursor.lockState);
        
        //Cursor.lockState = CursorLockMode.Confined;
        if (toggle.isOn)
        {
            print("togle true");
            if (blockearMouse == true)
            {
                Cursor.visible = false;
               
                Cursor.lockState = CursorLockMode.Locked;         
            }
            if (blockearMouse == false)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                //print("cursor visible true");
            }
        }
        else if(!toggle.isOn)
        {
            print("togle false");
            if (blockearMouse == true)
            {
                Cursor.visible = false;

                Cursor.lockState = CursorLockMode.Locked;
            }
            if (blockearMouse == false)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                //print("cursor visible true");
            }
        }    
        //if (toggle == false)
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //}
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggleMenu = !toggleMenu;         
        }      
        menu.SetActive(toggleMenu);
        if (toggleMenu)
        {
            PausarVideos();
            if (activarMouse != null)
            {
                blockearMouse = false;
            }
            // blockearMouse = false;
        }
        else if(toggleMenu == false)
        {
            ContinuarVideos();
            if (activarMouse != null)
            {
                blockearMouse = activarMouse.mouseBlockeado;
            }
        }
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.UpArrow))
        {
            acelerarVideos = !acelerarVideos;
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
        videoPlayers = FindObjectsOfType<VideoPlayer>();
        //for (int i = 0; i < videoPlayers.Length; i++)
        //{
        //    videoPlayers[i].SetDirectAudioVolume(0,sliderVolumenValue);
        //}
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
        FindObjectsOfType<VideoPlayer>();
    }
    public void AjustarCalidad()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("numeroDeCalidad", dropdown.value);
        calidad = dropdown.value;
    }
    public void RevisarResolucion()
    {
        resoluciones = Screen.resolutions;
        resolucionesDropdown.ClearOptions();
        List<string> opciones = new List<string>();
        int resoluconActual = 0;
        //opciones.Add(1920 + " x "+ 1080);
        //opciones.Add(1280 + " x " + 720);
        //opciones.Add(854 + " x " + 480);
        //opciones.Add(640 + " x " + 360);
        //for (int i = 0; i < opciones.Count; i++)
        //{
        //    if (resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)
        //    {
        //        resoluconActual = i;
        //    }
        //}

        for (int i = 0; i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            opciones.Add(opcion);

            if (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)
            {
                resoluconActual = i;
            }
        }
        resolucionesDropdown.AddOptions(opciones);
        resolucionesDropdown.value = resoluconActual;
        resolucionesDropdown.RefreshShownValue();
    }
    public void CambiarResolucion(int indiceResolution)
    {
        Resolution resolucion = resoluciones[indiceResolution];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }
    public void OcultarMouse()
    {
        if (blockearMouse == true)
        {
            //Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (blockearMouse == false)
        {
            //Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
    public void MostrarMouse()
    {
        
    }
}
