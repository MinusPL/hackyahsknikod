using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public bool inRange = false;
    public Interractable inter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            inter.Interract();
        }
    }

    public void SetInRange(Interractable interractable, bool flag)
    {
        inter = flag ? interractable : null;
        inRange = flag;
    }
}
