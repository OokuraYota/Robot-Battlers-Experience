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
    public void PushButton()
    {
        Debug.Log("<color=yellow>ボタンが押されたので、次のSceneに遷移します。</color>");
        SceneManager.LoadScene("ViewoftheworldScene");
    }
}