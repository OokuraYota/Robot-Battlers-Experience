using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

/// <summary>
/// EnemyBosを倒したら、PlayerWinNovelSceneに遷移する
/// </summary>
public class PlayerWinNovelSceneScript : MonoBehaviour
{
    public void PlayerWinCoroutine()
    {
        //コルーチンを呼び出す
        Debug.Log("プレイヤーの勝利");
        StartCoroutine("WinSceneTransition");
    }

    private IEnumerator WinSceneTransition()
    {
        Debug.Log("1.5秒後に、PlayerWinSceneに遷移します。");
        //1.5秒後にシーン遷移をする
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("PlayerWinScene");
    }
}