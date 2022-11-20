using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class BasePlayer : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private Camera camera;
    [SerializeField] float jumpscareCooldown;
    public float jumpscareTimer {get; private set;}

    public bool controlable;

    GameObject giraffe;

    public PlayerMovement Movement => movement;
    public PlayerInventory Inventory => inventory;
    public Camera Camera => camera;

    private void Awake() {
        // TODO: to be added to some global manager and removed from here
        Cursor.lockState = CursorLockMode.Locked;
        giraffe = GameObject.FindGameObjectWithTag("Giraffe");
        controlable = true;
    }

    public void ResetJumpscareTimer() => jumpscareTimer = 150;

    void Update()
    {
        jumpscareTimer -= Time.deltaTime;
        if (Vector3.Distance(transform.position, giraffe.transform.position) < 3)
        {
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        controlable = false;
        yield return new WaitForSeconds(3);
        if (inventory.hasTotem)
        {
            transform.position = inventory.respawnPos;
            inventory.hasTotem = false;
            controlable = true;
        }
    }
}
