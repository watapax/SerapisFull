using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class ChequearDistancia : MonoBehaviour
{
    public float minDistance;
    public Transform target;
    public UnityEvent onDistance;
    public bool returnInitialPosition = false;
    public Transform startPosition;

    private void Start()
    {
        if (startPosition == null)
        {
            startPosition = this.transform;
        }

    }

    public void CompararDistancia()
    {
        if(Vector3.Distance(transform.position , target.position)<= minDistance)
        {
            onDistance.Invoke();
        }
        else if(returnInitialPosition)
        {
            StartCoroutine(ReturnStartPosition(startPosition));
        }
    }
    IEnumerator ReturnStartPosition(Transform target)
    {
        Vector3 from = transform.position;
        float t = 0;
        float duracion = 0.3f;
        while (t < duracion)
        {
            t += Time.deltaTime;
            float perc = t / duracion;
            perc = Mathf.Sin(perc * Mathf.PI * 0.5f);
            transform.position = Vector3.Lerp(from, target.position, perc);
            yield return null;
        }
    }
}
