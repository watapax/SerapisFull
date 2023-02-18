using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MenuSalir : MonoBehaviour
{
    public GameObject menu;
    bool toggleMenu;
    VideoPlayer[] videoPlayers;
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
            videoPlayers[i].playbackSpeed = 1;
        }
    }
}
