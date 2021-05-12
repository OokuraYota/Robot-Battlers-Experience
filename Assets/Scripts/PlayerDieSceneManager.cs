using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDieSceneManager : MonoBehaviour
{
    /// <summary>
    /// プレイヤー
    /// </summary>
    public Player player;

    public void SceneTransition()
    {
        //もし、Playerのlifeが0になったら
        if (player.life <= 0)
        {
            //コルーチンを呼び出す処理の処理
            Debug.Log("★");
            EndBattleCoroutine();
        }
    }

    public void EndBattleCoroutine()
    {
        //コルーチンを呼び出す
        Debug.Log("★★");
        StartCoroutine("EndBattle");
    }

    /// <summary>
    /// 指定時間経過後に、PlayerDieSceneに遷移する
    /// </summary>
    /// <returns>PlayerDieScene</returns>
    private IEnumerator EndBattle()
    {
        Debug.Log("★★★");
        //1.7秒経過してから
        yield return new WaitForSeconds(1.7f);
        //Scene遷移
        SceneManager.LoadScene("PlayerDieScene");
    }
}
