using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// attach this script on a trigger
public class JumpscareTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent OnActivate;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            if (other.GetComponent<BasePlayer>().jumpscareTimer < 0)
                OnActivate.Invoke();
        }
    }
}
