using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//MonoBehaviourを継承することでオブジェクトコンポーネントとしてアタッチすることが出来る
//最終的にテキストファイルから読み出すことを考えて１つのパラメーターから名前も取得することにしてみる
public class TextGameManager : MonoBehaviour
{
    //SerializeFiledと書くとprivateなパラメータ―でもインスペクター上で値を変更することが出来る
    [SerializeField]
    private Text mainText;
    [SerializeField]
    private Text nameText;

    private string _text = "大倉「とても眠い。」";

    /// <summary>
    /// '「'この後ろからMainTextが始まる。
    /// </summary>
    private const char SEPARATE_MAIN_TEXT_START = '「';

    /// <summary>
    /// '」'により、MainTextの１文が終了する。
    /// </summary>
    private const char SEPARATE_MAIN_TEXT_END = '」';


    //MonoBehaviourを継承している場合限定で最初の更新関数(Updateメソッド)が呼ばれるときに呼ばれる
    private void Start()
    {
        //Main Textに指定したTextコンポーネントのテキストパラメーターに代入する。
        //mainText.text = _text;

        ReadLine(_text);
    }

    private void ReadLine(string text)
    {
        //'「'の位置で文字列を分ける
        string[] ts = text.Split(SEPARATE_MAIN_TEXT_START);
        //'「'で分けた時の最初の値、つまりName(大倉)が代入される。
        string name = ts[0];
        //'「'で分けた時の次の値、つまりMainTextに表示したい１文が代入される。
        //'」'で最後の閉じ括弧を削除して代入(="とても眠い")
        string main = ts[1].Remove(ts[1].LastIndexOf(SEPARATE_MAIN_TEXT_END));

        //配列の一番最初はNameTextに代入する
        nameText.text = name;

        mainText.text = main;
    }
}
