using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MantenerseLogeado : MonoBehaviour
{

    public static MantenerseLogeado instance;

    WaitForSeconds espera = new WaitForSeconds(15);    // cada 5 minutos actualiza el Token

    string urlLogout = "http://137.184.20.244:8000/api/logout/";
    string urlLogged = "http://137.184.20.244:8000/api/logged/";

    public string token;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    public string Token
    {
        set { token = value; }
    }

    public void SeguirLogeado()
    {
        StartCoroutine(Logged());
    }



    IEnumerator Logged()
    {
        print("Intentando");
        yield return espera;

        WWWForm postData = new WWWForm();
        postData.AddField("token", token);

        while (true)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Post(urlLogged, postData))
            {
                yield return webRequest.SendWebRequest();

                if (webRequest.result == UnityWebRequest.Result.Success)
                {
                    print("SIGO LOGEADO");
                }
            }

            yield return espera;
        }


    }


    IEnumerator Logout()
    {
        WWWForm postData = new WWWForm();
        postData.AddField("token", token);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(urlLogout, postData))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                print("SE SALIO");
            }
        }
    }

    private void OnApplicationQuit()
    {
        if(token != "")
            StartCoroutine(Logout());
    }

}
