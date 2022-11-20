using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingInterractable : Interractable
{
    [SerializeField]
    GameObject damaged;
    [SerializeField]
    float holdTime = 10f;
    [SerializeField]
    int lockNumber = 1;

    public bool done {get; private set;}
    public bool inProgress {get; private set;}

    private void Awake() {
        done = false;
        inProgress = false;
    }

    public override void Interract()
    {
        if (!done)
        {   inProgress = true;
            done = true;
            GlobalManager.blockPlayerMovement = true;
            Invoke("Release", holdTime);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        damaged.SetActive(false);
    }

    void Release()
    {   
        inProgress = false;
        GlobalManager.blockPlayerMovement = false;
        damaged.SetActive(true);
        GameObject.FindGameObjectWithTag("Door").GetComponent<DoorInterractable>().Unlock(lockNumber);
    }


}
