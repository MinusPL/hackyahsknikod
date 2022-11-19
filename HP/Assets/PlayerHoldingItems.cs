using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoldingItems : MonoBehaviour
{
    public GameObject TorchItem;
    public GameObject LeavesItem;

    bool torchAvaliable;
    bool leavesAvaliable;

    PlayerInventory PI;
    private void Start()
    {
        if (!GetComponent<PlayerInventory>())
            Debug.Log("No 'PlayerPickup' Script!");
        else
            PI = GetComponent<PlayerInventory>();
    }
    void Update()
    {
        #region bool
        if (PI.torches_amount > 0)
            torchAvaliable= true;
        else
            torchAvaliable= false;

        if (PI.leaves_amount > 0)
            leavesAvaliable = true;
        else
            leavesAvaliable = false;
        #endregion

        #region holding

        if (torchAvaliable)
            if (Input.GetKey("f"))
            {

            }

        #endregion
    }
}
