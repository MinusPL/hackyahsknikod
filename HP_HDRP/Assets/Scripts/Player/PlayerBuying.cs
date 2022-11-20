using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using System;

public class PlayerBuying : PlayerComponent
{
    Shaman shaman;
    public UnityEvent OnShamanClicked;
    public UnityEvent OnBought;
    bool pointingAtShaman;

    private void Start() {
        shaman = GameObject.FindObjectOfType<Shaman>();
    }

    private void FixedUpdate() {
        if (Physics.Raycast(player.Camera.transform.position, player.Camera.transform.forward, out var hit, 10))
        {
            pointingAtShaman = hit.collider.gameObject.CompareTag("Shaman");
        }
    }

    private void Update() {
        if (Input.GetMouseButtonUp(1) && pointingAtShaman)
        {
            // open shaman ui
            player.controlable = false;
            Cursor.lockState = CursorLockMode.None;
            OnShamanClicked.Invoke();
        }
    }

    public void Buy(int item)
    {
        ShamanTrade currentTrade = Array.Find(shaman.trades, trade => trade.soldItem == (Epickup)item);
        if (player.Inventory.red_frog_amount >= currentTrade.priceRedFrogs
        && player.Inventory.green_frog_amount >= currentTrade.priceGreenFrogs
        && player.Inventory.blue_frog_amount >= currentTrade.priceBlueFrogs
        && currentTrade.quantity > 0)
        {
            player.Inventory.red_frog_amount -= currentTrade.priceRedFrogs;
            player.Inventory.green_frog_amount -= currentTrade.priceGreenFrogs;
            player.Inventory.blue_frog_amount -= currentTrade.priceBlueFrogs;
            switch ((Epickup)item)
            {
                case Epickup.LEAVES:
                    player.Inventory.leaves_amount++;
                    OnBought.Invoke();
                    break;
                case Epickup.TORCH:
                    player.Inventory.torches_amount++;
                    OnBought.Invoke();
                    break;
                case Epickup.TOTEM:
                    player.Inventory.respawnPos = transform.position;
                    player.Inventory.hasTotem = true;
                    OnBought.Invoke();
                    break;
                default:
                    break;
            }
            currentTrade.quantity -= 1;
        }
    }
}