using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawnZMenor : MonoBehaviour
{
    public GameObject _npc;


    public float _clock;
    public float _timeToCreate;
    public float _range;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _clock += Time.deltaTime;
        if (_clock >= _timeToCreate)
        {
            _clock = 0;

            Vector3 _pos = transform.position;
            _pos.z = _pos.z - Random.Range(-_range, _range);
            _pos.x = _pos.x - Random.Range(-_range, _range);
            GameObject.Instantiate(_npc, _pos, Quaternion.identity);

        }

    }
}
