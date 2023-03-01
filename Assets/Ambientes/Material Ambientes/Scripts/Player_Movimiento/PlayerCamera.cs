using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public bool blockearMouse = true;
    // Start is called before the first frame update
    void Start()
    {
        //OcultarMouse();
    }

    // Update is called once per frame
    void Update()
    {
        //if (blockearMouse)
        //{
        //    OcultarMouse();
        //}
        //if (blockearMouse == false)
        //{
        //    MostrarMouse();
        //}
    }
    //public void OcultarMouse()
    //{
    //    Cursor.lockState = CursorLockMode.Locked;
    //    Cursor.visible = false;
    //}
    //public void MostrarMouse()
    //{
    //    Cursor.lockState = CursorLockMode.None;
    //    Cursor.visible = true;
    //}
}
