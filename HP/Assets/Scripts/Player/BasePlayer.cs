using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement))]
public class BasePlayer : MonoBehaviour
{
    public UnityEvent OnShamanClicked;
    [SerializeField] private Camera camera;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerInventory inventory;

    public PlayerMovement Movement => movement;
    public PlayerInventory Inventory => inventory;
    public Camera Camera => camera;

    private void Awake() {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
