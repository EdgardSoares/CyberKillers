using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float _speed;
    private float _waitTime;
    public float _startWaitTime;

    public Transform _moveSpot;
 

    public Transform _NPC1;

    Animator _anim;

    public float _minX;
    public float _maxX;
    public float _minZ;
    public float _maxZ;




    // Start is called before the first frame update
    void Start()
    {
        _waitTime = _startWaitTime;

        _anim = GetComponent<Animator>();

        _moveSpot.position = new Vector3(Random.Range(_minX, _maxX), 0.0f, Random.Range(_minZ, _maxZ));


    }

    // Update is called once per frame
    void Update()
    {
        _NPC1.transform.position = Vector3.MoveTowards(transform.position, _moveSpot.position, _speed * Time.deltaTime);
   


        if (Vector3.Distance(transform.position, _moveSpot.position) < 0.2f)
        {
            
            _anim.SetInteger("condi", 0);      // Stop Walking Animation and start Idle Animation
            if (_waitTime <= 0)
            {
                _moveSpot.position = new Vector3(Random.Range(_minX, _maxX), 0.0f, Random.Range(_minZ, _maxZ));
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
        Vector3 _spot = _moveSpot.position;      //posicao do spot
        Vector3 _npc = gameObject.transform.position;     // posicao no NPC
        Vector3 _delta = new Vector3(_spot.x - _npc.x, 0.0f, _spot.z - _npc.z);    //Fazendo com o que o NPC olhe na mesma direcao do spot
        Quaternion _rotation = Quaternion.LookRotation(_delta);    //Olhando
        gameObject.transform.rotation = _rotation;    //Rodando
    }
}
