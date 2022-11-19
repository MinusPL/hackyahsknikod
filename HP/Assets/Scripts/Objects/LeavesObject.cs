using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class LeavesObject : ObjectBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] BoxCollider collider;
    
    private void OnCollisionEnter(Collision other) {
        rb.isKinematic = true;
        collider.isTrigger = true;
    }
}