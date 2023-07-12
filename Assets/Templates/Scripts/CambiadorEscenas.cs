using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiadorEscenas : MonoBehaviour
{
    
    //Este script llama al ManagerEscenas para que vaya a la escena.
    //Se conecta automaticante si es que hay un boton, para simplificar las cosas.
    //Alternativamente se puede llamar la funcion CambiarDeEscena desde un evento u otro script.

    public string nombreEscenaDestino;
    public string IDAnclaDestino;
    public bool agregarEstrella = false;
    Button button;

    private void Start()
    {
        if(GetComponent<Button>() != null)
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnButtonPressed);
        }
    }

    public void OnButtonPressed()
    {
        //button.interactable = false;
        CambiarDeEscena();
    }

    public void CambiarDeEscena()
    {
        ManagerEscenas.Instance.CargarEscena(nombreEscenaDestino, "", IDAnclaDestino, "ZONA");
        if (agregarEstrella == true && ManagerEscenas.Instance.sceneStatusArray[UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex] == false)
        {
            AgregarEstrella();
            ManagerEscenas.Instance.sceneStatusArray[UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex] = true;
        }
    }
    void AgregarEstrella()
    {
        ManagerEscenas.Instance.AddStar();
    }
}
