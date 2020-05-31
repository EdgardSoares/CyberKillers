using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Analytics;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.Events;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI _display;
    public string[] _sentences;
    private int _index;
    public float _typingSpeed;
    public KeyCode _interactionbutton;
    public UnityEvent _interactionAction;

    public GameObject _pressE;

    ThirdPersonCharacter _player;

    private void Start()
    {
        _player = GameObject.Find("player").GetComponent<ThirdPersonCharacter>();
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "player")
        {

            StartTalk();
        }
    }



    void StartTalk()
    {
        _pressE.SetActive(true);
        StartCoroutine(Type());
        
    }



    void Update()
    {
        if(_display.text == _sentences[_index])
        {
            _pressE.SetActive(true);
            if (Input.GetKey(_interactionbutton))
            {
                _interactionAction.Invoke();
            }
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
        _pressE.SetActive(false);

        if(_index < _sentences.Length - 1)
        {
            _index++;
            _display.text = "";
            StartCoroutine(Type());
        } else
        {
            _display.text = "";
            _pressE.SetActive(false);
          
        }
    }
}
