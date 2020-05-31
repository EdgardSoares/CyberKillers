using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public float _speed;
    private float _waitTime;
    public float _startWaitTime;

    public Transform[] _moveSpot;
    private int _randomSpot;

    public NavMeshAgent _theAgent;
      

    Animator _anim;

   


    // Start is called before the first frame update
    void Start()
    {
        _waitTime = _startWaitTime;

        _anim = GetComponent<Animator>();

        _randomSpot = Random.Range(0, _moveSpot.Length);

        _theAgent = GetComponent<NavMeshAgent>();
        _anim.SetInteger("condi", 1);


    }

    // Update is called once per frame
    void Update()
    {
        //_theAgent.transform.position = Vector3.MoveTowards(transform.position, _moveSpot[_randomSpot].position, _speed * Time.deltaTime);

        _theAgent.SetDestination(_moveSpot[_randomSpot].position);

        //transform.position = Vector3.MoveTowards(transform.position, _moveSpot[_randomSpot].position, _speed * Time.deltaTime);
   

        if (Vector3.Distance(transform.position, _moveSpot[_randomSpot].position) < 0.2f)
        {            
            _anim.SetInteger("condi", 0);      // Stop Walking Animation and start Idle Animation
            if (_waitTime <= 0)
            {
                _randomSpot = Random.Range(0, _moveSpot.Length);
                _waitTime = _startWaitTime;
                FaceSpot();    // Chamando funcao para o NPC olhar para o spot
                _anim.SetInteger("condi", 1);   //Play Walking Animation
            }  else
            {
                _waitTime -= Time.deltaTime;
            }
        }
        
    }

    //Function para fazer com que o NPC olhe para o lugar onde estara se locomovendo
    void FaceSpot()
    {
        Vector3 _spot = _moveSpot[_randomSpot].position;      //posicao do spot
        Vector3 _npc = gameObject.transform.position;     // posicao no NPC
        Vector3 _delta = new Vector3(_spot.x - _npc.x, 0.0f, _spot.z - _npc.z);    //Fazendo com o que o NPC olhe na mesma direcao do spot
        Quaternion _rotation = Quaternion.LookRotation(_delta);    //Olhando
        gameObject.transform.rotation = _rotation;    //Rodando
    }
}
