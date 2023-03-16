using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public float speedX;
    public float speedY;
    public Material material;
    void Update()
    {
        material.mainTextureOffset += new Vector2(speedX,speedY) * Time.deltaTime;
    }
}
