using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CambiarCamara : MonoBehaviour
{
    public CinemachineVirtualCamera camaraPrender;
    public CinemachineVirtualCamera camaraApagar;
    //public PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            camaraPrender.Priority = 20;
            camaraApagar.Priority = 1;
        }
    }
}
