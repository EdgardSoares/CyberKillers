using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDestoy : MonoBehaviour
{
    public GameObject _npc;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Character_Hacker_Female_01(Clone)")
        {
            GameObject.Destroy(_npc);
        }
    }
}
