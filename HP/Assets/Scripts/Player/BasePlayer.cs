using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class BasePlayer : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;

    public PlayerMovement Movement => movement;

    private void Awake() {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
