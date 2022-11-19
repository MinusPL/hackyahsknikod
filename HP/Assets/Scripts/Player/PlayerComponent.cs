using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    protected BasePlayer player;

    protected virtual void Awake()
    {
        player = GetComponent<BasePlayer>();
    }
}
