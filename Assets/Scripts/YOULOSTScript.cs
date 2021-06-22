using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class YOULOSTScript : MonoBehaviour
{
    [SerializeField]
    private GameObject TextY;
    [SerializeField]
    private GameObject TextO;
    [SerializeField]
    private GameObject TextU;
    [SerializeField]
    private GameObject TextL;
    [SerializeField]
    private GameObject TextO2;
    [SerializeField]
    private GameObject TextS;
    [SerializeField]
    private GameObject TextT;

    public void Start()
    {
        //『YOULOST』を爆発がちゃんと見えるように非アクティブにしておく
        TextY.SetActive(false);
        TextO.SetActive(false);
        TextU.SetActive(false);
        TextL.SetActive(false);
        TextO2.SetActive(false);
        TextS.SetActive(false);
        TextT.SetActive(false);

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
        TextL.SetActive(true);
        TextO2.SetActive(true);
        TextS.SetActive(true);
        TextT.SetActive(true);
    }
}
