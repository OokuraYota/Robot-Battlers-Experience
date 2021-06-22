using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioSord : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;

    public void Start()
    {
        //Componetを取得
        audioSource = GetComponent<AudioSource>();
    }

    public void AudioSoud1()
    {
        audioSource.PlayOneShot(sound1);
    }
}
