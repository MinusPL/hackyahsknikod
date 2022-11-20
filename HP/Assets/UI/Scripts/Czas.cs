using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;


public class Czas : MonoBehaviour
{
    public TextMeshProUGUI Tekst;
    public bool flag;
    private float time;
    private void OnEnable()
    {
        Debug.Log("Wczytano postać");
        flag = true;
    }

    private void Update()
    {
        // odpala licznik od momentu utworzenia obiektu postaci na scenie
        if (flag)
        {
            time += Time.deltaTime;
            Tekst.text = time.ToString("F2");

        }
    }
}
