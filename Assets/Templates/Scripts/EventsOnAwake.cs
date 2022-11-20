using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsOnAwake : MonoBehaviour
{
    public UnityEvent onAwake;

    private void Awake()
    {
        onAwake.Invoke();
    }

}
