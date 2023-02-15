using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarCollidersEnChild : MonoBehaviour
{
    public bool modelos3d = false;
    public void DesactivatCollider(GameObject parent)
    {
        if (modelos3d)
        {
            Collider[] colliders = parent.GetComponentsInChildren<Collider>();
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = false;
                print("Desactivando");
            }
        }
        else
        {
            Collider2D[] colliders = parent.GetComponentsInChildren<Collider2D>();
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = false;
                print("A" + i);
            }
        }
       
    }

    public void ActivarColliders(GameObject parent)
    {
        
        if (modelos3d)
        {
            print("Activando");
            Collider[] colliders = parent.GetComponentsInChildren<Collider>();
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = true;
            }
        }
        else
        {
            Collider2D[] colliders = parent.GetComponentsInChildren<Collider2D>();
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = true;
            }
        }      
    }
}
