using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : PlayerComponent
{ 
    [SerializeField] SoundPool sounds;

    float stepInterval;
    private void Start() {
        stepInterval = .5f;
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            stepInterval -= Time.deltaTime * (Input.GetKey(KeyCode.LeftShift) ? 1.4f : 1);
            if (stepInterval <= 0)
            {
                stepInterval = .5f;
                sounds.PlayRandom(0, 6);
            }
        }
    }
}
