using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscena : MonoBehaviour
{
    public GameObject canva;
    
    float time = 6f;

    private void Start()
    {
        canva.SetActive(true);
    }

    private void Update()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
//            Destroy(canva);
        canva.SetActive(false);
        }
    }
}
