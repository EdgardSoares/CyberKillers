﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAINav : MonoBehaviour
{

    public GameObject _destination;
    NavMeshAgent _theAgent;
    // Start is called before the first frame update
    void Start()
    {
        _theAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _theAgent.SetDestination(_destination.transform.position);
        //RichMan Destroy
        if(transform.position.z >= 68)
        {
            GameObject.Destroy(gameObject);
        }
        
    }


}
