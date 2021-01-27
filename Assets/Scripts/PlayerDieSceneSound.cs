using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDieSceneSound : MonoBehaviour
{
    public AudioClip AudioClip;

    private void Start()
    {
        AudioSource.PlayClipAtPoint(AudioClip, this.gameObject.transform.position);
        NovelSceneTransition();
    }

    public void NovelSceneTransition()
    {
        //コルーチンを呼び出す処理の処理
        Debug.Log("シナリオSceneにむけ、コルーチンを呼び出します");
        EndBattleCoroutine();
    }

    public void EndBattleCoroutine()
    {
        //コルーチンを呼び出す
        Debug.Log("コルーチン呼び出し中");
        StartCoroutine("NovelScene");
    }

    /// <summary>
    /// PlayerのDieAnimationが終了した頃にScene移動
    /// </summary>
    /// <returns></returns>
    public IEnumerator NovelScene()
    {
        //５秒後に
        Debug.Log("５秒後に");
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("PlayerDieNovelScene");
    }
}
