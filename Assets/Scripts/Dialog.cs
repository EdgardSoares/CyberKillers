using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Analytics;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI _display;
    public string[] _sentences;
    private int _index;
    public float _typingSpeed;

    public GameObject _continueButton;

    void Start()
    {
        
           StartCoroutine(Type());
       
       
    }

   
    void Update()
    {
        if(_display.text == _sentences[_index])
        {
            _continueButton.SetActive(true);
        }
    }
    IEnumerator Type()
    {
        foreach (char letter in _sentences[_index].ToCharArray())
        {
            _display.text += letter;
            yield return new WaitForSeconds(_typingSpeed);

        }
    }

    public void NextSentences()
    {
       _continueButton.SetActive(false);

        if(_index < _sentences.Length - 1)
        {
            _index++;
            _display.text = "";
            StartCoroutine(Type());
        } else
        {
            _display.text = "";
           _continueButton.SetActive(false);
        }
    }
}
