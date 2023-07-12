using UnityEngine;
using UnityEngine.Events;
public class ManagerActividad : MonoBehaviour
{
    public UnityEvent onCompletarActividad;

    public int cantidadDeRespuestas;
    int respuestasAsignadas = 0;
    public bool agregarEstrella = false;
    public void AgregarRespuestaCorrecta()
    {
        respuestasAsignadas++;

        if (respuestasAsignadas == cantidadDeRespuestas)
        {
            print("Completo Actividad");
            onCompletarActividad.Invoke();
            if (agregarEstrella)
            {
                ManagerEscenas.Instance.sceneStatusArray[UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex] = true;
                ManagerEscenas.Instance.AddStar();
            }   
        }

    }

    public void QuitarRespuesta()
    {
        respuestasAsignadas--;
    }

}
