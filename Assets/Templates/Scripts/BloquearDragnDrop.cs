using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloquearDragnDrop : MonoBehaviour
{
    public void BloquearDrag(GameObject _parent)
    {
        DragNdrop[] dnd = _parent.GetComponentsInChildren<DragNdrop>();
        for (int i = 0; i < dnd.Length; i++)
        {
            dnd[i].BloquearDrag();
        }
    }

    public void DesbloquearDrag(GameObject _parent)
    {
        DragNdrop[] dnd = _parent.GetComponentsInChildren<DragNdrop>();
        for (int i = 0; i < dnd.Length; i++)
        {
            dnd[i].DesbloquearDrag();
        }
    }
}
