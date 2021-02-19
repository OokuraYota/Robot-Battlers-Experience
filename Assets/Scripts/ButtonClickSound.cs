using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.SceneManagement;

/// <summary>
/// Buttonを押したときのSound
/// </summary>
public class ButtonClickSound : MonoBehaviour
{
    /// <summary>
    /// ボタンを押したらなる音源
    /// </summary>
    private AudioSource soundSource;


    void Start()
    {
        soundSource = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        //soundSource.PlayOneShot(soundSource.clip);

        //2021 02 19
        soundSource.Play();

        StartCoroutine(Checking(() =>
        {
            Debug.Log("END");

            StartTransition();
            //SceneManager.LoadScene("ViewoftheworldScene");
        }));
    }

    public delegate void functionType();

    private IEnumerator Checking(functionType callback)
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            if (!soundSource.isPlaying)
            {
                callback();
                break;
            }
        }
    }

    public void StartTransition()
    {
        Debug.Log("遷移を始めます");
        SceneManager.LoadScene("ViewoftheworldScene");
    }
}

