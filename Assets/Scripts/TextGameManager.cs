using System.Collections;
using System.Collections.Generic;  //記述
using System.Security;
using UnityEngine;
using UnityEngine.UI;

// MonoBehaviorを継承することでオブジェクトにコンポーネントとして
// アタッチすることが出来る
public class TextGameManager : MonoBehaviour
{
    // SerialaizeFieldと書くとprivateなパラメータでも
    // インスペクター上で値を変更できる。

    [SerializeField]
    private Text mainText;
    [SerializeField]
    private Text nameText;

    //private string _text = "Hello,Wolrd";

    private const char SEPARATE_MAIN_STAET = '『';
    private const char SEPARATE_MAIN_END = '』';

    //private string _text = "Name + MainText" 
    //private string _text = "みにに『Hello,World』";
    //private string _text = "大倉『こうだい、しばま\n" + "おやすみ\n" + "私も寝ます』";

    //パラメーターを追加
    private Queue<char> _charQueue;

    //パラメーターを追加
    [SerializeField]
    private float captionSpeed = 0.2f;

    //パラメーターを追加
    private const char SEPARATE_PAGE = '&';
    private Queue<string> _pageQueue;

    //パラメーターを追加 ページの区切り文字は＆　これをページの跨ぎたい箇所の間に挟む　a『b』＆c『d』なら　Name a Main b クリックすると Name c 『d』と表示される
    private string _text = "大倉『こんにちは\nこんばんわ\nおはようございます』&大倉『これはテキストの表示サンプルです』&芝間『こんにちは』";

    //MonoBehaviorを継承している場合限定で
    //最初の更新関数（Updateメソッド）が呼ばれるときに最初に呼ばれる。
    private void Start()
    {
        //Main Textに指定したTextコンポーネントの
        //テキストのパラメーターに代入する。
        //mainText.text = _text;
        //ReadLine(_text);
        Init();
    }


    private Queue<char> SeparateString(string str)
    {
        //文字列をchar型の配列にする　=　１文字ごとに区切る 
        char[] chars = str.ToCharArray();
        Queue<char> charQueue = new Queue<char>();

        //foreach文で配列charsに格納された文字を全て取り出し
        //キューに加える
        foreach (char c in chars) charQueue.Enqueue(c);
        return charQueue;
    }

    /// <summary>
    /// １文字を出力する
    /// </summary>
    private bool OutputChar()
    {
        //キューに何も格納されていなければfalseを返す
        if (_charQueue.Count <= 0) return false;

        //キューからは値を取り出し、キュー内からは削除する。
        mainText.text += _charQueue.Dequeue();
        return true;
    }

    private IEnumerator ShowChars(float wait)
    {
        //OutputCharメソッドがfalseを返す（＝キューが空になる）までループする
        while (OutputChar())
        {
            yield return new WaitForSeconds(wait);
        }
        //コルーチンを抜け出す
        yield break;
    }

    /// <summary>
    /// １行を読みだす
    /// </summary>
    /// <param name="text"></param>
    private void ReadLine(string text)
    {
        //'『'の位置で文字列を分ける
        string[] ts = text.Split(SEPARATE_MAIN_STAET);

        //分けた時の最初の値、つまり"みにに"が代入される
        string name = ts[0];

        //分けた時の次の値、つまり"Hello,World!』"が代入されるので
        //最後の閉じ括弧を削除して代入（="Hello,World!"）
        string main = ts[1].Remove(ts[1].LastIndexOf(SEPARATE_MAIN_END));
        nameText.text = name;
        mainText.text = "";

        _charQueue = SeparateString(main);

        //コルーチンを呼び出す
        StartCoroutine(ShowChars(captionSpeed));
    }

    //メソッドを追加
    //全文を表示する
    private void OutputAllChar() //2021 01 20
    {
        //コルーチンをストップ
        StopCoroutine(ShowChars(captionSpeed));
        //キューが空になるまで表示
        while (OutputChar()) ;
    }


    //クリックしたときの処理
    private void OnClick()
    {
        //OutputAllChar();
        if (_charQueue.Count > 0)
        {
            OutputAllChar();
        }
        else
        {
            if (!ShowNextPage())
            {
                //UnityエディタのPlayモードを終了する
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }


    //MonoBhaviourを継承している場合限定で毎フレーム呼ばれる。
    private void Update()
    {
        //左（＝０）がクリックされたらOnClickメソッドを呼び込む
        if (Input.GetMouseButtonDown(0)) OnClick();
    }

    private Queue<string> SeparateString(string str, char sep)
    {
        string[] strs = str.Split(sep);
        Queue<string> queue = new Queue<string>();
        foreach(string l in strs) queue.Enqueue(l);
        return queue;
    }


    /// <summary>
    /// 初期化する
    /// </summary>
    private void Init()
    {
        _pageQueue = SeparateString(_text, SEPARATE_PAGE);
        ShowNextPage();
    }


    /// <summary>
    /// 次のページを表示する
    /// </summary>
    /// <returns></returns>
    private bool ShowNextPage()
    {
        if (_pageQueue.Count <= 0) return false;
        ReadLine(_pageQueue.Dequeue());
        return true;
    }
}
