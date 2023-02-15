using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirLink : MonoBehaviour
{
    public void AbrirEnlace(string enlace)
    {
        Application.OpenURL(enlace);
    }

}
