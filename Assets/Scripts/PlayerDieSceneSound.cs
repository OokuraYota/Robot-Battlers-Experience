using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieSceneSound : MonoBehaviour
{
    public AudioClip AudioClip;

    private void Start()
    {
        AudioSource.PlayClipAtPoint(AudioClip, this.gameObject.transform.position);
    }
}
