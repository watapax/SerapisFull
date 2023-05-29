using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;
using System.Linq;

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
    private string intEstrellas = "estrellas";
    public int estrellas;
    public GameObject objStar;
    public TextMeshProUGUI textStar;
    public int totalScenes;
    public bool[] sceneStatusArray;
    private const string sceneStatusKey = "SceneStatusArray";
    public static ManagerEscenas Instance { get; private set; }

    void Awake()
    {
        //totalScenes = SceneManager.sceneCountInBuildSettings;
        //sceneStatusArray = new bool[totalScenes];

        // Cargar el array guardado en PlayerPrefs
        int totalScenes = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        sceneStatusArray = new bool[totalScenes];

        // Cargar el array guardado en PlayerPrefs
        if (PlayerPrefs.HasKey(sceneStatusKey))
        {
            string savedArray = PlayerPrefs.GetString(sceneStatusKey);
            string[] savedArrayElements = savedArray.Split(',');

            for (int i = 0; i < savedArrayElements.Length && i < sceneStatusArray.Length; i++)
            {
                if (bool.TryParse(savedArrayElements[i], out bool value))
                {
                    sceneStatusArray[i] = value;
                }
            }
        }
        //
        estrellas = PlayerPrefs.GetInt("estrellas");
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
        textStar.text = estrellas + "/50";
        int nivel = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        if (nivel >= 3 && nivel <= 12)
        {
            objStar.SetActive(true);
        }
        else
        {
            objStar.SetActive(false);
        }
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.Alpha0))
        {
            PlayerPrefs.SetInt(intEstrellas, 0);
            estrellas = 0;
            for (int i = 0; i < sceneStatusArray.Length; i++)
            {
                sceneStatusArray[i] = false;
            }

            // Guardar el array actualizado en PlayerPrefs
            string arrayString = string.Join(",", sceneStatusArray.Select(b => b.ToString()).ToArray());
            PlayerPrefs.SetString(sceneStatusKey, arrayString);
            PlayerPrefs.Save();
        }
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerPrefs.SetInt(intEstrellas, estrellas + 1);
            estrellas = PlayerPrefs.GetInt("estrellas");
        }
        //Cursor.visible = true;

        // if (Input.GetKeyDown(KeyCode.UpArrow)) Time.timeScale = 3;
        // if (Input.GetKeyDown(KeyCode.DownArrow)) Time.timeScale = 1;

    }

    void Debugear()
    {
        if (debugMode)
            Debugear();
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(intEstrellas,estrellas);
        string arrayString = string.Join(",", sceneStatusArray.Select(b => b.ToString()).ToArray());
        PlayerPrefs.SetString(sceneStatusKey, arrayString);
        PlayerPrefs.Save();
    }
    public void AddStar()
    {
        PlayerPrefs.SetInt(intEstrellas, estrellas + 1);
        estrellas = PlayerPrefs.GetInt("estrellas");
    }
}
