using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAnclas:MonoBehaviour
{
    public GameObject menu;
    public GraphicRaycaster graphicRaycaster;
    public Scrollbar scrollbar;
    bool is_open = false;
    float key_press_time = 0;
    public MenuSalir menuSalir;

    //CursorLockMode prevMouseLockMode;
    //bool prevMouseVisibleState;

    private void Start()
    {
        ApagarMenu();
        menuSalir = FindObjectOfType<MenuSalir>();
    }

    private void OnLevelWasLoaded()
    {
        menuSalir = FindObjectOfType<MenuSalir>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_open)
        {
            if (Input.GetKey(KeyCode.F10) || Input.GetKey(KeyCode.P))
            {
                key_press_time += Time.deltaTime;
                if (key_press_time > 1.0)
                {              
                    is_open = true;
                    menu.SetActive(true);
                    graphicRaycaster.enabled = true;
                    scrollbar.value = 1;
                    /*
                    prevMouseLockMode = Cursor.lockState;
                    prevMouseVisibleState = Cursor.visible;
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = true;
                    */
                    if (menuSalir.activarMouse != null)
                    {
                        menuSalir.activarMouse.mouseBlockeado = false;
                       // print("cursor visible true");
                    }
                    else
                    {
                        menuSalir.blockearMouse = false;
                    }                  
                }
            }
            else if(Input.GetKeyUp(KeyCode.F10) || Input.GetKeyUp(KeyCode.P))
            {
                key_press_time = 0;
            }
        } 
        else
        {
            if (Input.GetKeyDown(KeyCode.F10) || Input.GetKeyDown(KeyCode.P))
            {
                key_press_time = 0;
                is_open = false;
                menu.SetActive(false);
                
                if (menuSalir.activarMouse != null)
                {
                    menuSalir.activarMouse.mouseBlockeado = true;
                    //print("cursor visible false");
                }
                //graphicRaycaster.enabled = false;

                // Cursor.lockState = prevMouseLockMode;
                //Cursor.visible = prevMouseVisibleState;
            }
        }

    }

    public void ApagarMenu()
    {
        key_press_time = 0;
       // scrollbar.value = 1;
        is_open = false;
        menu.SetActive(false);
        //graphicRaycaster.enabled = false;

        //Cursor.lockState = prevMouseLockMode;
        //Cursor.visible = prevMouseVisibleState;
    }
}
