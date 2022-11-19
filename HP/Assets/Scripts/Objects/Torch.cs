using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TorchBehaviour : ObjectBehaviour
{
    [SerializeField] Light torchLight;
    [SerializeField] float initLifeTime;
    
    float lifeTime;
    float initLightIntensity;

    private void Awake() {
        initLightIntensity = torchLight.intensity;
    }

    public override void Tick(float delta)
    {
        
    }

    public void Regenerate()
    {

    }
}