using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TotemObject : MonoBehaviour
{
    public Vector3 respawnPos;
    private void Start() 
    {
        respawnPos = transform.position;
    }
}