using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnDisable : MonoBehaviour
{
    public UnityEvent evento;

    private void OnDisable()
    {
        evento.Invoke();
    }
}
