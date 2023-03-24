using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class InicioSesion : MonoBehaviour
{
    public GameObject panelError, panelOk;
    public TextMeshProUGUI textoError;   
    public TMP_InputField userInput, passInput;
    public string urlLogin;
    string respuesta;
    



    
    private void Start()
    {
        passInput.inputType = TMP_InputField.InputType.Password;
    }

    public void IntentarLogin()
    {
        StartCoroutine(Login());
    }

    IEnumerator Login()
    {
        respuesta = "";
        WWWForm postData = new WWWForm();

        postData.AddField("username", userInput.text);
        postData.AddField("password", passInput.text);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(urlLogin, postData))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                panelError.SetActive(true);
                textoError.text = "Error de conexión";
            }
            else
            {
                string r = webRequest.downloadHandler.text.ToString();


                for(int i = 1; i < r.Length-1; i++)
                {
                    respuesta += r[i];
                }


                if (respuesta == "full")
                {
                    panelError.SetActive(true);
                    textoError.text = "Todas las licencias están ocupadas";
                }
                else if (respuesta == "no")
                {
                    panelError.SetActive(true);
                    textoError.text = "Usuario o Contraseña incorrecta";
                }
                else
                {
                    panelOk.SetActive(true);
                    MantenerseLogeado.instance.Token = respuesta;
                    MantenerseLogeado.instance.SeguirLogeado();
                }
                    
     
            }
        }

    }


}
