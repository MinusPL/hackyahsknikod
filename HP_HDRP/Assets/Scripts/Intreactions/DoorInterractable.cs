using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInterractable : Interractable
{
    [SerializeField]
    Transform leftDoor;
    [SerializeField]
    Transform rightDoor;

    [SerializeField]
    GameObject lock1;
    [SerializeField]
    GameObject lock2;
    [SerializeField]
    GameObject lock3;
    [SerializeField]
    GameObject lock4;
    [SerializeField]
    GameObject lock5;

    [SerializeField]
    float rotationSpeed = 50f;

    bool rotating = false;
    bool rotated = false;

    float accumulatedRotation = 0f;

    int unlocked = 5;

    private void Update()
    {
        if(rotating)
        {
            leftDoor.Rotate(0f, -rotationSpeed * Time.deltaTime, 0f, Space.Self);
            rightDoor.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);
            accumulatedRotation += rotationSpeed * Time.deltaTime;
            if(accumulatedRotation >= 75f)
            {
                rotated = true;
                rotating = false;
            }
        }
    }


    public override void Interract()
    {
        if (!rotated && unlocked <= 0) rotating = true;
    }

    public void Unlock(int i)
    {
        switch(i)
        {
            case 1:
                lock1.SetActive(false);
                break;
            case 2:
                lock2.SetActive(false);
                break;
            case 3:
                lock3.SetActive(false);
                break;
            case 4:
                lock4.SetActive(false);
                break;
            case 5:
                lock5.SetActive(false);
                break;
        }
        unlocked--;
    }
}
