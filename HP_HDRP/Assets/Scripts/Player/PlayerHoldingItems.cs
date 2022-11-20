using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoldingItems : PlayerComponent
{
    [SerializeField] private TorchBehaviour torchItem;

    /// <summary>
    /// add prefab here
    ///</summary>
    [SerializeField] private GameObject leavesPrefab;

    [SerializeField] private float throwStrength;
    [SerializeField] private int leavesRequired;

    bool torchAvaliable => player.Inventory.torches_amount > 0;
    bool leavesAvaliable => player.Inventory.leaves_amount >= leavesRequired;
    void Update()
    {

        #region holding
        if (player.controlable)
        {
            if (torchAvaliable)
            {
                if (Input.GetKeyUp("f"))
                {
                    // use torch
                    if (torchItem.isLit)
                    {
                        torchItem.Extinguish();
                    }
                    else {
                        torchItem.Ignite();
                        player.Inventory.torches_amount--;
                    }
                }
            }
    
            if(leavesAvaliable){
                if (Input.GetMouseButtonUp(0))
                {
                    if (Physics.Raycast(player.Camera.transform.position, transform.forward, out var hit, 2))
                    // throw leaves
                    {
                        var leaves = Instantiate(leavesPrefab, transform.position + Vector3.up + transform.forward * 1.6f, transform.rotation);
                        leaves.GetComponent<Rigidbody>().velocity = 10 * transform.forward;
                        player.Inventory.leaves_amount -= leavesRequired;
                    }
                }
            }
        }
        #endregion
    }
}
