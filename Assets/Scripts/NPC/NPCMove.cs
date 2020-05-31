using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : MonoBehaviour
{

    private float _speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _pos = transform.position;
        _pos.z = _pos.z + _speed * Time.deltaTime;
        transform.position = _pos;
        
    }
}
