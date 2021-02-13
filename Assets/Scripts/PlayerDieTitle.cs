using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDieTitle : MonoBehaviour
{
    /// <summary>
    /// PlayerDieSceneNovelからTitleに遷移する際にくるくる回しながら色を変える画像
    /// </summary>
    [SerializeField]
    public Image PlayerDieNovelTitleImage;

    /// <summary>
    /// 透明度が変わるスピードを管理
    /// </summary>
    [SerializeField]
    public float fadeSpeed = 0.0014f;

    /// <summary>
    /// パネルの色、不透明度を管理
    /// </summary>
    float red, green, blue, alfa;

    public bool isFadeOut = false;
    public bool isFadeIn = false;

    void Start()
    {
        //取得しておく
        PlayerDieNovelTitleImage = GetComponent<Image>();
        red = PlayerDieNovelTitleImage.color.r;
        green = PlayerDieNovelTitleImage.color.g;
        blue = PlayerDieNovelTitleImage.color.b;
        alfa = PlayerDieNovelTitleImage.color.a;
    }

    public void Update()
    {
        //Updateに記入すると、毎フレームごとに、Z軸を中心に10度ずつ回転させる。
        transform.Rotate(new Vector3(0, 0, 1));

        if (isFadeIn)
        {
            StartFadeIn();
        }
        if (isFadeOut)
        {
            StartFadeOut();
        }
    }

    public void StartFadeIn()
    {
        //alfa値を徐々に下げているので不透明度をfadeSpeed分下げる
        alfa -= fadeSpeed;

        //変更した不透明度パネルを反映
        SetAlpha();

        //完全に透明になったら処理を抜ける
        if (alfa <= 0)
        {
            isFadeIn = false;
            PlayerDieNovelTitleImage.enabled = false;　　　//パネルの表示をオフにする
        }
    }

    void StartFadeOut()
    {
        PlayerDieNovelTitleImage.enabled = true;  //パネルの表示をオンにする
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
        PlayerDieNovelTitleImage.color = new Color(red, green, blue, alfa);
    }
}
