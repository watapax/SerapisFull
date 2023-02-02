using UnityEngine;
using UnityEngine.SceneManagement;


public class Volver : MonoBehaviour
{

    public string[] ambientes;
    public GameObject botonVolver;

    private void Update()
    {
        botonVolver.SetActive(!OnAmbiente());
    }

    bool OnAmbiente()
    {
        int s = 0;

        string cs = SceneManager.GetActiveScene().name;
        for (int i = 0; i < ambientes.Length; i++)
        {
            if (cs == ambientes[i]) s++;
        }
        return s > 0;
    }
}
