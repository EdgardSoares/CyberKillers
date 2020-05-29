using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float _speed;
    public Transform[] _moveSpots;
    public int _randomSpots;

    public float _startWaitTime;
    public float _waitTime;

    // Start is called before the first frame update
    void Start()
    {
        _waitTime = _startWaitTime;
        _randomSpots = Random.Range(0, _moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _moveSpots[_randomSpots].position, _speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, _moveSpots[_randomSpots].position) < 0.2f)
        {
            if (_waitTime <= 0)
            {
                _randomSpots = Random.Range(0, _moveSpots.Length);
                _waitTime = _startWaitTime;
            } else
            {
                _waitTime -= Time.deltaTime;
            }

        }
    }
}
