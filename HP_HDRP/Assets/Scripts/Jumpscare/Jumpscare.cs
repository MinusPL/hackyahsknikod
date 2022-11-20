using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    [SerializeField] GameObject jumpscareImage;
    [SerializeField] AudioSource clip;

    public void Trigger()
    {
        StartCoroutine(JumpscareAction());
    }

    IEnumerator JumpscareAction()
    {
        clip.Play();
        jumpscareImage.SetActive(true);
        yield return new WaitForSeconds(2);
        jumpscareImage.SetActive(false);
    }
}
