using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPool : MonoBehaviour
{

    [SerializeField] AudioClip[] clips;
    [SerializeField] AudioSource source;
    private void Awake() {
    }

    public void PlayRandom(int rangeMin, int rangeMax)
    {
        Play(Random.Range(rangeMin, rangeMax));
    }

    public void Play(int index)
    {
        source.clip = clips[index];
        source.Play();
    }
}
