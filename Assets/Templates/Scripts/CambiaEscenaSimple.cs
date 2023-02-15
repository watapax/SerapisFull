using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiaEscenaSimple : MonoBehaviour
{
    public void CargarEscena(string escena)
    {
        if(GetComponentInParent<MenuAnclas>())
        GetComponentInParent<MenuAnclas>().ApagarMenu();
        SceneManager.LoadScene(escena);
    }
}
