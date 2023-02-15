using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ManagerEscenas : MonoBehaviour
{
    string ultimaEscena;
    string nombreSiguienteEscena;
    string IDAnclaEntrada;
    string IDAnclaDestino;
    string tipoEscena;
    public UnityEvent onLoadScene;
    float waitTime;
    public AudioManager audioManager;

    public static ManagerEscenas Instance { get; private set; }

    void Awake()
    {
        //Se borra a si mismo si hay otro activo
        if (Instance != null && Instance != this) 
        { 
            Debug.Log("Existing manager found, deleting self...");
            Destroy(this.gameObject); 
        } 
        else 
        { 
            Debug.Log("No manager found, setting self as new manager...");
            Instance = this; 
        } 

        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        
        waitTime = GetComponent<ManagerTransicionCanvas>().duracionFade +1;
        SceneManager.sceneLoaded += TerminarCarga;
    }
    private void OnLevelWasLoaded()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void CargarEscena(string nombreEscena, string newIDAnclaEntrada,string newIDAnclaDestino, string newTipoEscena)
    {
        ultimaEscena = SceneManager.GetActiveScene().name;
        nombreSiguienteEscena = nombreEscena;
        tipoEscena = newTipoEscena;
        IDAnclaEntrada = newIDAnclaEntrada;
        IDAnclaDestino = newIDAnclaDestino;

        onLoadScene.Invoke();
        if (audioManager != null)
        {
            audioManager.AudioOut();
        }      
        Invoke("Cargar", waitTime);
    }

    public void CargarUltimaEscena()
    {
        CargarEscena(ultimaEscena,"NULO",IDAnclaEntrada, "ZONA"); //Esto asume que la ultima escena era una Zona
    }

    void Cargar()
    {   
        SceneManager.LoadScene(nombreSiguienteEscena);       
    }

    public void CargarEscena(string _nombreEscena)
    {
        SceneManager.LoadScene(_nombreEscena);
    }

    void TerminarCarga(Scene scene, LoadSceneMode mode)
    {
        GetComponent<ManagerTransicionCanvas>().FadeOutBlanco();
        
        if (tipoEscena == "ZONA") //Esto no toma en cuenta el retorno de una actividad, OJO
        {
                     GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                Debug.Log("Setting player pos");

                GameObject[] anclasDestino = GameObject.FindGameObjectsWithTag("Ancla");

                if(anclasDestino.Length != 0)
                {
                    foreach (var ancla in anclasDestino)
                    {
                        if (ancla.GetComponent<ZonaAncla>().IDAncla == IDAnclaDestino)
                        {
                            player.transform.position = ancla.GetComponent<ZonaAncla>().returnPosHelper.position;
                            break;
                        }
                    }
                }
            }
        }
        else
        {
           // Cursor.lockState = CursorLockMode.None;
        }

    }




    [SerializeField]
    bool debugMode;

    private void Update()
    {

        Cursor.visible = true;

       // if (Input.GetKeyDown(KeyCode.UpArrow)) Time.timeScale = 3;
       // if (Input.GetKeyDown(KeyCode.DownArrow)) Time.timeScale = 1;

    }

    void Debugear()
    {
        if (debugMode)
            Debugear();
    }

}
