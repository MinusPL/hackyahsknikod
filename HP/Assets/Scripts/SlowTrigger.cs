using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTrigger : MonoBehaviour
{
    [SerializeField]
    private float duration = 5.0f;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Giraffe"))
        {
            other.GetComponent<GiraffeController>().SetSlowDebuff(duration);
        }
    }
}
