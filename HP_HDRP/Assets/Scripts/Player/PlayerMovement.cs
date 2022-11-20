using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerComponent
{
    [SerializeField] private CharacterController cc;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float speed;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float sprintSpeedMultiplier;
    [SerializeField] private KeyCode sprintKey;
    [SerializeField] private float sprintMaxValue;
    [SerializeField] private float sprintDepletionRate;
    [SerializeField] private float sprintRegenRate;

    public float sprintStamina { get; private set; }
    private bool canSprint;
    private bool isSprinting;

    private void Start() 
    {
        sprintStamina = 10;
        canSprint = true;
    }
    void Move(float h, float v)
    {
        Vector3 moveDelta = (h * transform.right + v * transform.forward) * speed * Time.deltaTime;
        isSprinting = Input.GetKey(sprintKey) && v > 0;
        if (isSprinting && canSprint)
        {
            moveDelta *= sprintSpeedMultiplier;
            sprintStamina -= sprintDepletionRate * Time.deltaTime;
            if (sprintStamina <= 0)
            {
                canSprint = false;
            }
        }
        cc.Move(moveDelta); 
    }

    void Rotate(float dx, float dy)
    {
        transform.eulerAngles += new Vector3(0, dx * mouseSensitivity, 0);
        var pe = playerCamera.transform.eulerAngles;
        pe.x -= dy * mouseSensitivity;
        if (pe.x >= 90 && pe.x < 180)
        {
            pe.x = 90;
        }
        if (pe.x <= 270 && pe.x > 180)
        {
            pe.x = -90;
        }
        playerCamera.transform.eulerAngles = pe;
    }

    private void Update()
    {
        if (!GlobalManager.pause)
        {
            float axisH = Input.GetAxis("Horizontal");
            float axisV = Input.GetAxis("Vertical");
            float axisMouseX = Input.GetAxis("Mouse X");
            float axisMouseY = Input.GetAxis("Mouse Y");

            Rotate(axisMouseX, axisMouseY);
            if (!GlobalManager.blockPlayerMovement)
            {
                Move(axisH, axisV);

                if (!(isSprinting && canSprint))
                {
                    if (sprintStamina >= sprintMaxValue)
                    {
                        sprintStamina = sprintMaxValue;
                        if (!canSprint) canSprint = true;
                    }
                    else
                    {
                        sprintStamina += sprintRegenRate * Time.deltaTime;
                    }
                }
            }
        }
    }
}
