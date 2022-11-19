using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class BasePlayer : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerInventory inventory;

    public PlayerMovement Movement => movement;
    public PlayerInventory Inventory => inventory;

    private void Awake() {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
