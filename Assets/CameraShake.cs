using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.Mathematics;

public class CameraShake : MonoBehaviour
{
   // public static CameraShake Instance;
    public CinemachineVirtualCamera cinemachineVirtual;

    [SerializeField]
    private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;

    private float tiempoMovimiento;

    private float tiempoMovimientoTotal;

    private float intensidadInicial;
    public float intensidad;
    public float frecuencia;
    public float tiempo;

    private void Awake()
    {
        //cinemachineVirtual = GetComponent<CinemachineVirtualCamera>();
        cinemachineBasicMultiChannelPerlin = cinemachineVirtual.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       //Instance = this;
        if (tiempoMovimiento > 0)
        {
            tiempoMovimiento -= Time.deltaTime;
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(intensidadInicial, 0, 1 - (tiempoMovimiento / tiempoMovimientoTotal));
            //print("uwu");
        }
    }
    //public void MoverCamara(float intensidad, float frecuencia, float tiempo)
    //{
    //    cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensidad;
    //    cinemachineBasicMultiChannelPerlin.m_FrequencyGain = frecuencia;
    //    intensidadInicial = intensidad;
    //    tiempoMovimientoTotal = tiempo;
    //    tiempoMovimiento = tiempo;
    //}
    public void Shake()
    {     
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensidad;
        cinemachineBasicMultiChannelPerlin.m_FrequencyGain = frecuencia;
        intensidadInicial = intensidad;
        tiempoMovimientoTotal = tiempo;
        tiempoMovimiento = tiempo;
    }
}
