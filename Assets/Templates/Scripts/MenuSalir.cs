using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSalir : MonoBehaviour
{
    public GameObject menu;
    bool toggleMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            toggleMenu = !toggleMenu;

        menu.SetActive(toggleMenu);
            
    }

    public void Salir()
    {
        Application.Quit();
    } 

    public void Quedarse()
    {
        toggleMenu = false;
    }
}
