using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //パネルのイメージを操作するのに必要


public class FadeContorller : MonoBehaviour
{
    float fadeSpeed = 0.0014f;   //透明度が変わるスピードを管理(0.0023f;良い感じ)
    float red, green, blue, alfa;   //パネルの色、不透明度を管理

    public bool isFadeOut = false;
    public bool isFadeIn = false;

    //public bool isFadeOut = true;  //フェードアウト処理の開始、完了を管理するフラグ
    //public bool isFadeIn = true;   //フェードイン処理の開始、完了を管理するフラグ

    public Image fadeImage;   //透明度を変更するパネルのイメージ

    void Start()
    {
        //取得しておく
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }

    void Update()
    {
        if (isFadeIn)
        {
            StartFadeIn();
        }
        if (isFadeOut)
        {
            StartFadeOut();
        }
        /*if (isFadeIn == true)
        {
            StartFadeIn();
        }
        else if (isFadeOut == true)
        {
            StartFadeOut();
        }*/

    }

    void StartFadeIn()
    {
        alfa -= fadeSpeed;           //不透明度を徐々に下げる
        SetAlpha();                  //変更した不透明度パネルを反映する
        if (alfa <= 0)　　　　　　　　//完全に透明になったら処理を抜ける
        {
            //isFadeIn = false;
            isFadeIn = false;
            fadeImage.enabled = false;　　　//パネルの表示をオフにする
        }
    }
    void StartFadeOut()
    {
        fadeImage.enabled = true;  //パネルの表示をオンにする
        alfa += fadeSpeed;         //不透明度を徐々にあげる
        SetAlpha();                //変更した透明度をパネルに反映する
        if (alfa >= 1)　　　　　　　//完全に不透明になったら処理を抜ける
        {
            //isFadeOut = false;
            isFadeOut = false;
        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
