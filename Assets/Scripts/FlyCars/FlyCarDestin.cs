using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlyCarDestin : MonoBehaviour
{
    public float _speed;
    private float _waitTime;
    public float _startWaitTime;

    public Transform[] _moveSpot;
    public int _randomSpot;

    Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _waitTime = _startWaitTime;
           

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, _moveSpot[_randomSpot].position, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _moveSpot[_randomSpot].position) < 0.2f)
        {
            _randomSpot += 1;
            if (_waitTime <= 0)
            {
                
                _waitTime = _startWaitTime;
                FaceSpot();
            }
            else
            {
                _waitTime -= Time.deltaTime;
                
            }
        }

        if (_randomSpot == 8)
        {
            _randomSpot = 0;
        }

    }


    void FaceSpot()
    {
        Vector3 _spot = _moveSpot[_randomSpot].position;      //posicao do spot
        Vector3 _npc = gameObject.transform.position;     // posicao no NPC
        Vector3 _delta = new Vector3(_spot.x - _npc.x, 0.0f, _spot.z - _npc.z);    //Fazendo com o que o NPC olhe na mesma direcao do spot
        Quaternion _rotation = Quaternion.LookRotation(_delta);    //Olhando
        gameObject.transform.rotation = _rotation;    //Rodando
    }
}
