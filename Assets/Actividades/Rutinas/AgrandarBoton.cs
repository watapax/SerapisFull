using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgrandarBoton : MonoBehaviour
{
    public float multiplicar;

    public void Agrandar()
    {
        transform.localScale = this.transform.localScale * multiplicar;
    }
    public void VolverAlaNormalidad()
    {
        transform.localScale = this.transform.localScale / multiplicar;
    }
}
