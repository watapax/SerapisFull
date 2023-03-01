using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD:MonoBehaviour
{
    public GameObject InfoGameObject;
    public TextMeshProUGUI sceneTypeText;
    public TextMeshProUGUI sceneNametext;
    public RectTransform background;
    public Image previewImage;
    public GameObject preview;
    public bool isShowing;
    public MenuSalir menuSalir;

   

    //Singleton stuff
    public static HUD Instance { get; private set; }
    private void Awake()
    {
        menuSalir = FindObjectOfType<MenuSalir>();
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        } else
        {
            Instance = this;
        }
    }
    public void ShowAnclaInfo()
    {
        //InfoGameObject.SetActive(true);
        InfoGameObject.GetComponent<Animator>().Play("Hide");
        InfoGameObject.GetComponent<Animator>().SetBool("IsShowing", true);
        InfoGameObject.GetComponent<Animator>().Play("Show");
        isShowing = true;
        menuSalir.activarMouse.mouseBlockeado = false;
        print("cursor visible true");
    }

    public void HideAnclaInfo()
    {
        //InfoGameObject.SetActive(false);
        InfoGameObject.GetComponent<Animator>().SetBool("IsShowing", false);
        //InfoGameObject.GetComponent<Animator>().Play("Hide");
        isShowing = false;
        menuSalir.activarMouse.mouseBlockeado = true;
        print("cursor visible false");
    }

    public void SetAnclaInfo(string newType, string newName, Sprite newSprite)
    {
        sceneTypeText.SetText(newType);
        sceneNametext.SetText(newName);
        previewImage.sprite = newSprite;

        if (newType == "ACTIVIDAD")
        {
            sceneNametext.color = new Color(1, 0.950f, 0.350f);
            preview.SetActive(false);
            background.localPosition = new Vector3(background.localPosition.x, 600, background.localPosition.z);
        } else
        {
            sceneNametext.color = new Color(0.55f, 0.85f, 1f);
            preview.SetActive(true);
            background.localPosition = new Vector3(background.localPosition.x, 375, background.localPosition.z);
            
        }
    }
}
