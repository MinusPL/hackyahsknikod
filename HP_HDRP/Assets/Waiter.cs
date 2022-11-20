using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waiter : MonoBehaviour
{
    public GameObject canvas;
    float t = 0f;
    float waittime = 10f;

    void Start()
    {
        if (t < 0)
        {
            t += Time.deltaTime / waittime;
        }
        Destroy(canvas);
    }
}
