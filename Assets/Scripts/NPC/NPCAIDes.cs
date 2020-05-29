using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCAIDes : MonoBehaviour
{

    public int _pivoPoints;
    void OnTriggerEnter(Collider other)
    {
               
        if(other.tag == "npc")
        {
            if(_pivoPoints == 2)
            {
                _pivoPoints = 0;
            }

            if(_pivoPoints == 1)
            {
                this.gameObject.transform.position = new Vector3(-14.29f, 0.2f, -1.85f);
                _pivoPoints = 2;
            }

            if (_pivoPoints == 0)
            {
                this.gameObject.transform.position = new Vector3(-2.83f, 0.2f, -1.85f);
                _pivoPoints = 1;
            }
        }
    }
}
