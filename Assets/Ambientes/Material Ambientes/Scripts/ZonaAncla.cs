using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ZonaAncla:MonoBehaviour
{
    public enum AnclaTypes { ZONA, ACTIVIDAD,ELEMENTO };
    public AnclaTypes tipoAncla;
    public string IDAncla;
    public string IDAnclaDestino;
    public string nombreEscena;
    //public float distanciaActivacion;
    public Outline AnclaMeshOutline;


    [Header("Informacion UI")]
    public string nombreAncla;
    public Sprite previewAncla;
    [TextArea(10,10)]
    public string informacionElemento;
    public GameObject goInfo;

    private bool playerCanClick = false;
    private bool isEnteringWorld = false;

    [HideInInspector] public Transform returnPosHelper;

    private GameObject player;

    public GameObject Desactrivar;//elemento que desactivamos si es un elemento


    private void Awake()
    {
        returnPosHelper = transform.Find("ReturnPosHelper");
        
    }

    private void Start()
    {
        goInfo = GameObject.FindGameObjectWithTag("SceneInfo");
        //goInfo.SetActive(false);
        if (AnclaMeshOutline != null)
        {
            AnclaMeshOutline.enabled = false;
        }

        if (tipoAncla == AnclaTypes.ACTIVIDAD)
        {
            transform.Find("Indicator").gameObject.SetActive(false);
        }
    }

    void Update()
    {
        print("Player can click" + playerCanClick);
        if (playerCanClick && !isEnteringWorld && Input.GetMouseButtonDown(0) && tipoAncla != AnclaTypes.ELEMENTO)
        {
            ManagerEscenas.Instance.CargarEscena(nombreEscena, IDAncla, IDAnclaDestino, tipoAncla.ToString());
            playerCanClick = false;
            isEnteringWorld = true;
            HUD.Instance.HideAnclaInfo();
        }

        
        /* //This part of the script allows for a different way of detecting the player
        //If player is in Ancla zone, calculate distance
        if (player != null)
        {

            //If player is within set distance, show HUD info
            if (Vector3.Distance(player.transform.position, transform.position) < distanciaActivacion)
            {
                if (!HUD.Instance.isShowing)
                {
                    HUD.Instance.ShowAnclaInfo();
                    HUD.Instance.SetAnclaInfo(tipoAncla.ToString(), nombreAncla, previewAncla);
                    StartCoroutine(WaitAndEnableClick(0.6f, true)); //Waits for animation to end before enabling teleport
                }

            } else
            {
                if (HUD.Instance.isShowing)
                {
                    HUD.Instance.HideAnclaInfo();
                    playerCanClick = false;
                }

            }
        }*/
    }

    void ActivateAnclaInfo()
    {
        
       HUD.Instance.ShowAnclaInfo();
        if (tipoAncla != AnclaTypes.ELEMENTO)
        {
            HUD.Instance.SetAnclaInfo(tipoAncla.ToString(), nombreAncla, previewAncla,null);
            goInfo.SetActive(false);
            
        }
        if (tipoAncla == AnclaTypes.ELEMENTO)
        {
            
            HUD.Instance.SetAnclaInfo(tipoAncla.ToString(), nombreAncla, previewAncla,informacionElemento);
            goInfo.SetActive(true);
        }
        StartCoroutine(WaitAndEnableClick(0.4f, true)); //Waits for animation to end before enabling teleport
                                                        //Cursor.lockState = CursorLockMode.Confined;
                                                        //Cursor.visible = true;
        if (tipoAncla == AnclaTypes.ELEMENTO)
        {
            Desactrivar.SetActive(false);
            playerCanClick = false;
        }
    }

    void DeactivateAnclaInfo()
    {
        HUD.Instance.HideAnclaInfo();
        playerCanClick = false;

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        if (tipoAncla == AnclaTypes.ELEMENTO)
        {
            goInfo.SetActive(false);
            Desactrivar.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (AnclaMeshOutline != null)
        {
            AnclaMeshOutline.enabled = true;
        }

        player = other.gameObject;
        ActivateAnclaInfo();
    }

    private void OnTriggerExit(Collider other)
    {
        if (AnclaMeshOutline != null)
        {
            AnclaMeshOutline.enabled = false;
        }

        player = null;
        DeactivateAnclaInfo();
    }

    private IEnumerator WaitAndEnableClick(float waitTime, bool newValue)
    {
        yield return new WaitForSeconds(waitTime);

        if (player != null && tipoAncla != AnclaTypes.ELEMENTO)
        {
            playerCanClick = newValue;
        }
        
    }

    /*
    void OnDrawGizmosSelected()
    {
        // Draw a sphere to show activation distance
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaActivacion);
    }*/
}
