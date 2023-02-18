using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;

public class ControladorPorVoz : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;

    Dictionary<string, Action> wordToAction;
    // Start is called before the first frame update
    void Start()
    {
        wordToAction = new Dictionary<string, Action>();
        wordToAction.Add("aliwen", Aliwen);
        wordToAction.Add("ko", Ko);
        wordToAction.Add("rayen", Rayen);
        keywordRecognizer = new KeywordRecognizer(wordToAction.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += WordReconized;
        keywordRecognizer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void WordReconized(PhraseRecognizedEventArgs word)
    {
        wordToAction[word.text].Invoke();
    }
    public void Aliwen()
    {
        print("Muy Bien!!, aliwen es arbol en mapudungun");
    }
    public void Ko()
    {
        print("Muy Bien!, KO es Agua en mapudungun");
    }
    public void Rayen()
    {
        print("Muy Bien!, Rayen es Flor en mapudungun");
    }
}
