using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 次のSceneに遷移するScript
/// </summary>
public class StartButtonTitle : MonoBehaviour
{
    //2021年 7月6日
    public void SB()
    {
        Debug.Log("ボタンが押された");
        SceneManager.LoadScene("ViewoftheworldScene");
    }
}