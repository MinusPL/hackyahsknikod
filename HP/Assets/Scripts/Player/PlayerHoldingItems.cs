using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoldingItems : PlayerComponent
{
    [SerializeField] private GameObject torchItem;

    /// <summary>
    /// add prefab here
    ///</summary>
    [SerializeField] private GameObject leavesPrefab;

    bool torchAvaliable => PI.torches_amount > 0;
    bool leavesAvaliable => PI.leaves_amount >= 5;

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

        #region holding

        if (torchAvaliable)
        {
            if (Input.GetKeyUp("f"))
            {
                // use torch
                
            }
        }

        if(leavesAvaliable){
            if (Input.GetMouseButtonUp(0))
            {
                // throw leaves
                var leaves = Instantiate(leavesPrefab, transform.position + Vector3.up + transform.forward * 1.6f, transform.rotation);
                leaves.GetComponent<Rigidbody>().velocity = 10 * transform.forward;
                player.Inventory.leaves_amount -= 5;
            }
        }
        else torchItem.SetActive(false);
        #endregion
    }
}
