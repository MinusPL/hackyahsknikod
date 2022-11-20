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
    float rotationSpeed = 50f;

    bool rotating = false;
    bool rotated = false;

    float accumulatedRotation = 0f;

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
        if (!rotated) rotating = true;
    }
}
