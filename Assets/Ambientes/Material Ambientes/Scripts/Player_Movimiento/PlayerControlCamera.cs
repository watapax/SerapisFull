using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerControlCamera : MonoBehaviour
{
    public float sensibilidad;
    bool canMoveCamera;
    private void Start()
    {
        CinemachineCore.GetInputAxis = HandleAxisInputDelegate;
    }

    public void CamArea(bool _canMoveCamera) => canMoveCamera = _canMoveCamera;

    float HandleAxisInputDelegate(string axisName)
    {
        if (canMoveCamera)
        {
            switch (axisName)
            {
                case "Mouse X":
                    if (Input.touchCount > 0)
                        return Input.touches[0].deltaPosition.x / sensibilidad;
                    else
                        return Input.GetAxis(axisName);

                case "Mouse Y":
                    if (Input.touchCount > 0)
                        return Input.touches[0].deltaPosition.y / sensibilidad;
                    else
                        return Input.GetAxis(axisName);

                default:
                    Debug.LogError("Input <" + axisName + "> no se reconoce", this);
                    break;
            }
        }


        return 0f;
    }
}
