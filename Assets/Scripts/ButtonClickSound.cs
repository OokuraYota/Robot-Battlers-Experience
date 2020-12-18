using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Buttonを押したときのSound
/// </summary>
public class ButtonClickSound : MonoBehaviour
{
    private AudioSource STRAT;

    void Start()
    {
        STRAT = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        STRAT.PlayOneShot(STRAT.clip);
    }
}

