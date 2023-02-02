using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiadorBoton : MonoBehaviour
{
    public string nombreEscenaDestino;
    public string IDAnclaDestino;



    public void CambiarDeEscena()
    {
        ManagerEscenas.Instance.CargarEscena(nombreEscenaDestino, "", IDAnclaDestino, "ZONA");
    }
}
