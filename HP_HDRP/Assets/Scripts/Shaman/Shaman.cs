using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public struct ShamanTrade
{
    public Epickup soldItem;
    public int quantity;
    public int priceRedFrogs;
    public int priceGreenFrogs;
    public int priceBlueFrogs;
}

public class Shaman : MonoBehaviour
{
    public ShamanTrade[] trades;

    public void Sell(int item)
    {
        for (int i = 0; i < trades.Length; i++)
        {
            if (trades[i].soldItem == (Epickup)item)
            {
                trades[i].quantity--;
                break;
            }
        }
    }
}