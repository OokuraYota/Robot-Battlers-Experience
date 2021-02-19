using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWinScript : MonoBehaviour
{
    /// <summary>
    /// 『Y』のテキスト
    /// </summary>
    [SerializeField]
    private GameObject TextY;

    /// <summary>
    /// 『O』のテキスト
    /// </summary>
    [SerializeField]
    private GameObject TextO;

    /// <summary>
    /// 『U』のテキスト
    /// </summary>
    [SerializeField]
    private GameObject TextU;

    /// <summary>
    /// 『W』のテキスト
    /// </summary>
    [SerializeField]
    private GameObject TextW;

    /// <summary>
    /// 『I』のテキスト
    /// </summary>
    [SerializeField]
    private GameObject TextI;

    /// <summary>
    /// 『N』のテキスト
    /// </summary>
    [SerializeField]
    private GameObject TextN;

    public void Start()
    {
        //爆発がちゃんと見えるように、『YOUWIN』を非アクティブにしておく
        TextY.SetActive(false);
        TextO.SetActive(false);
        TextU.SetActive(false);
        TextW.SetActive(false);
        TextI.SetActive(false);
        TextN.SetActive(false);
    }

    public void Update()
    {
        //コルーチンを実装
        StartCoroutine("WaitingTime");
    }

    public IEnumerator WaitingTime()
    {
        //0.7秒待ったら
        yield return new WaitForSeconds(1.42f);
        Debug.Log("2.5秒待ったら");

        DisplayOnTheScreen();
    }

    public void DisplayOnTheScreen()
    {
        Debug.Log("爆発が見終わったので、画面に文字を表示");
        TextY.SetActive(true);
        TextO.SetActive(true);
        TextU.SetActive(true);
        TextW.SetActive(true);
        TextI.SetActive(true);
        TextN.SetActive(true);
    }
}
