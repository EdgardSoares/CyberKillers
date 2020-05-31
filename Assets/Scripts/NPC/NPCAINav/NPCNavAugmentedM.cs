using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;
using UnityEngine.AI;

public class NPCNavAugmentedM : MonoBehaviour
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

        if(transform.position.z >= 45)
        {
            GameObject.Destroy(gameObject);
        } 
    }
}
