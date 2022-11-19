using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerShamanIntegration : PlayerComponent
{
    private void Update() 
    {
        if (Input.GetMouseButtonUp(1))
        {
            if (Physics.Raycast(transform.position + transform.up, player.Camera.transform.forward, out var hit, 10))
            {
                if (hit.collider.transform.CompareTag("Shaman"))
                {
                    // open shaman interaction
                    player.OnShamanClicked.Invoke();
                }
            }
        }
    }
}