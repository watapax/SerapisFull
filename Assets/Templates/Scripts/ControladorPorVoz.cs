using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;
using UnityEngine.Events;

public class ControladorPorVoz : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;

    Dictionary<string, Action> wordToAction;
    public UnityEvent[] eventosPalabras;
    public string[] palabras;
    private bool activo;
    public bool[] PalabraActiva = new bool[3] { true, true, true };
    // Start is called before the first frame update
    void Start()
    {
        wordToAction = new Dictionary<string, Action>();
        //wordToAction.Add("aliwen", Palabra1);
        //wordToAction.Add("ko", Palabra2);
        //wordToAction.Add("rayen", Palabra3);
        wordToAction.Add(palabras[0], Palabra1);
        wordToAction.Add(palabras[1], Palabra2);
        wordToAction.Add(palabras[2], Palabra3);
        keywordRecognizer = new KeywordRecognizer(wordToAction.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += WordReconized;
        keywordRecognizer.Start();
    }

    private void OnEnable()
    {
        activo = true;
    }
    private void OnDisable()
    {
        activo = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void WordReconized(PhraseRecognizedEventArgs word)
    {
        wordToAction[word.text].Invoke();
        
    }
    public void Palabra1()
    {
        if (activo && PalabraActiva[0] == true)
        {
            eventosPalabras[0].Invoke();
        }
        else
        {
            print("No estoy activo");
        }
        print("Dijo la palabra");
    }
    public void Palabra2()
    {
        if (activo && PalabraActiva[1] == true)
        {
            eventosPalabras[1].Invoke();
        }
        else
        {
            print("No estoy activo");
        }
        print("Dijo la palabra");
    }
    public void Palabra3()
    {
        if (activo && PalabraActiva[2] == true)
        {
            eventosPalabras[2].Invoke();
        }
        else
        {
            print("No estoy activo");
        }
        
        print("Dijo la palabra");
    }
    public void ActivarPalabra( int nPalabra)
    {
        PalabraActiva[nPalabra] = true;
    }
    public void DesactivarPalabra(int nPalabra)
    {
        PalabraActiva[nPalabra] = false;
    }
}
