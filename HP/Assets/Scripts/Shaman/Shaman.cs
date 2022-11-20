using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public struct ShamanTrade
{
    public Epickup soldItem;
    public int quantity;
    public float priceRedFrogs;
    public float priceGreenFrogs;
    public float priceBlueFrogs;
}

public class Shaman : MonoBehaviour
{
    public ShamanTrade[] trades;
}