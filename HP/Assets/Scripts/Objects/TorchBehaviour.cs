using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TorchBehaviour : MonoBehaviour
{
    [SerializeField] Light torchLight;
    [SerializeField] float initLifeTime;
    [SerializeField] float flickerSpeed;
    [SerializeField] float fadeOutTime = 5f;
    [SerializeField] bool litOnStart = true;

    public bool isLit{get; private set;}
    
    float lifeTime;
    float initLightIntensity;
    float baseLightIntensity;

    private void Awake() {
        initLightIntensity = torchLight.intensity;
        if (litOnStart) Ignite();
    }

    private void Update() {
        baseLightIntensity = Mathf.Lerp(0, initLightIntensity, Mathf.Clamp01(lifeTime / fadeOutTime));
        isLit = lifeTime > 0;
        lifeTime -= isLit ? Time.deltaTime : 0;
        torchLight.intensity = baseLightIntensity + ((Mathf.PerlinNoise(Time.time * flickerSpeed, -Time.time * flickerSpeed) * .1f) - .05f);

        torchLight.enabled = isLit;
    }

    public void Ignite()
    {
        lifeTime = initLifeTime;
    }

    public void Extinguish()
    {
        lifeTime = 0;
    }
}