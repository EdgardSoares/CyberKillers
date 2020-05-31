using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.ThirdPerson;

public class NPCApprouch : MonoBehaviour
{

    //Variaveis de Interecao do NPC com o Player
    public bool _isRange = false;
    public KeyCode _interectionKey;
    public UnityEvent _interecAction;
    public ThirdPersonCharacter _player;


    //Variaveis para o Dialogo
    public TextMeshProUGUI _display;
    public string[] _sentences;
    private int _index;
    public float _typingSpeed;
    public GameObject _continueButton;
    public GameObject _dialogoCanvas;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("player").GetComponent<ThirdPersonCharacter>();
        
      
    }

    // Update is called once per frame
    void Update()
    {
        if(_isRange == true)
        {
            if (Input.GetKey(_interectionKey))
            {
                _interecAction.Invoke();
                // Start Coroutine!!
                //StartCoroutine(Type());

            }
        }

       /* if(_display.text == _sentences[_index])
        {
            _continueButton.SetActive(true);
        }*/

       
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "player")
        {
            _isRange = true;
  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "player")
        {
            _isRange = false;
            _dialogoCanvas.SetActive(false);
        }
    }
    /*
    public IEnumerator Type()
    {
        foreach (char letter in _sentences[_index].ToCharArray())
        {
            _display.text += letter;
            yield return new WaitForSeconds(_typingSpeed);
        }
    }

    public void NextSenteces()
    {
        
            Debug.Log("Apertou E");
            if (_index < _sentences.Length - 1)
            {
                _index++;
                _display.text = "";
                StartCoroutine(Type());
            }
            else
            {
                _display.text = "";

            }

       
    }*/



}
