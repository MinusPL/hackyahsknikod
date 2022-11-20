using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class IntrectionTrigger : MonoBehaviour
{
    [SerializeField]
    Interractable iobj;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInteraction>().SetInRange(iobj, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInteraction>().SetInRange(iobj, false);
        }
    }
}
