using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgrandarBoton : MonoBehaviour
{
    public float multiplicar;

    public void Agrandar(GameObject boton)
    {
        boton.transform.localScale = boton.transform.localScale * multiplicar;
    }
    public void VolverAlaNormalidad(GameObject boton)
    {
       boton.transform.localScale = boton.transform.localScale / multiplicar;
    }
}
