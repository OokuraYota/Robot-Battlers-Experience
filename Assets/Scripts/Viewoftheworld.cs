using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//MonoBehaviourを継承することでオブジェクトコンポーネントとしてアタッチすることが出来る
//最終的にテキストファイルから読み出すことを考えて１つのパラメーターから名前も取得することにしてみる
public class Viewoftheworld : MonoBehaviour
{
    //SerializeFiledと書くとprivateなパラメータ―でもインスペクター上で値を変更することが出来る
    [SerializeField]
    private Text mainText;
    [SerializeField]
    private Text nameText;

    //private string _text = "大倉「とても眠い。\nだけど、プログラミングやらなくちゃ...」";
    //private string _text = "大倉「とても眠い」&大倉２「だけど、プログラミングやらなくちゃ」";

    /// <summary>
    /// '「'この後ろからMainTextが始まる。
    /// </summary>
    private const char SEPARATE_MAIN_TEXT_START = '「';

    /// <summary>
    /// '」'により、MainTextの１文が終了する。
    /// </summary>
    private const char SEPARATE_MAIN_TEXT_END = '」';

    private Queue<char> _charQueue;

    /// <summary>
    /// 文字表示までの待ち時間
    /// </summary>
    [SerializeField]
    private float captionSpeed = 0.09f;

    /// <summary>
    /// ページの区切り文字
    /// </summary>
    private const char SEPARATE_PAGE = '&';
    private Queue<string> _pageQueue;

    /// <summary>
    /// 右下の▼
    /// </summary>
    [SerializeField]
    private GameObject nextPageIcon;

    /// <summary>
    /// Assets/Resources/Textsフォルダの『Scenario.txt』
    /// </summary>
    [SerializeField]
    private string textFile = "Texts/Viewoftheworld";

    private string _text = "";


    //MonoBehaviourを継承している場合限定で最初の更新関数(Updateメソッド)が呼ばれるときに呼ばれる
    private void Start()
    {
        //Main Textに指定したTextコンポーネントのテキストパラメーターに代入する。
        //mainText.text = _text;

        //ReadLine(_text);
        //OutputChar();

        Init();
    }

    private void Update()
    {
        //左(= 0)クリックされたらOnClickメソッドを呼び出す
        if (Input.GetMouseButtonDown(0)) OnClick();
    }

    private void ReadLine(string text)
    {
        //'「'の位置で文字列を分ける
        string[] ts = text.Split('「');
        //'「'で分けた時の最初の値、つまりName(大倉)が代入される。
        string name = ts[0];
        //'「'で分けた時の次の値、つまりMainTextに表示したい１文が代入される。
        //'」'で最後の閉じ括弧を削除して代入(="とても眠い")
        string main = ts[1].Remove(ts[1].LastIndexOf('」'));

        //配列の一番最初はNameTextに代入する
        nameText.text = name;

        mainText.text = "";

        _charQueue = SeparateString(main);

        //コルーチンを呼び出す
        StartCoroutine(ShowChars(captionSpeed));
    }

    /// <summary>
    /// 文を１文字ごとに区切り、キューに格納したものを返す。
    /// </summary>
    /// <param name="str">文字列【１文】</param>
    /// <returns></returns>
    private Queue<char> SeparateString(string str)
    {
        //文字列をchar型の配列にする = １文字ごとに区切る。
        char[] chars = str.ToCharArray();
        Queue<char> charQueue = new Queue<char>();

        //forech文で配列charsに格納された文字を全て取り出し、Queueに加える。
        foreach (char c in chars) charQueue.Enqueue(c);
        return charQueue;

    }

    /// <summary>
    /// １文字を出力する。
    /// </summary>
    private bool OutputChar()
    {
        //キューに何も格納されていなければfalseを返す
        if (_charQueue.Count <= 0)
        {
            //キューに何も格納されてないってことは、表示する文字がないから
            //次押してねってことの▼を表示する
            nextPageIcon.SetActive(true);
            return false;
        }

        //キューから値を取り出し、キュー内からは削除する
        mainText.text += _charQueue.Dequeue();

        return true;
    }

    private IEnumerator ShowChars(float wait)
    {
        //OutputCharメソッドがfalseを返す(=キューが空になる)までループする
        while (OutputChar())
            //wait秒だけ待機
            yield return new WaitForSeconds(wait);
        //コルーチンを抜け出す
        yield break;
    }

    /// <summary>
    /// 全文を表示する
    /// </summary>
    private void OutputAllChar()
    {
        //コルーチンをストップ
        StopCoroutine(ShowChars(captionSpeed));
        //キューが空になるまで待機
        while (OutputChar()) ;
        //これが呼ばれてるってことは、全部表示したから▼のオブジェクトを表示する
        nextPageIcon.SetActive(true);
    }

    /// <summary>
    /// クリックしたときの処理
    /// </summary>
    private void OnClick()
    {
        //クリックしたら、コルーチンを止め、全文を表示するメソッドを呼ぶ
        //OutputAllChar();

        if (_charQueue.Count > 0)
        {
            //まだキューに残っていたら、残り全部表示する
            OutputAllChar();
        }
        else
        {
            if (!ShowNextPage())
            {
                //UnityエディタのPlayモードを終了する
                //だから、現時点では２ページ進んでクリックしたらPlayモードが終了する
                ////UnityEditor.EditorApplication.isPlaying = false; ←Playモード終了のやつ

                //ここがクリックしたら終わりのところだから、最後の文をクリックしたらSceneをタイトルにする敵な感じ
                //にすればよいかな
                SceneManager.LoadScene("BattleScene");
            }
        }
    }

    /// <summary>
    /// 文字列を指定した区切りごとに区切り、キューに格納したものを返す
    /// </summary>
    /// <param name="str">文字列</param>
    /// <param name="sep"></param>
    /// <returns></returns>
    private Queue<string> SeparateString(string str, char sep)
    {
        string[] strs = str.Split(sep);
        Queue<string> queue = new Queue<string>();
        foreach (string l in strs) queue.Enqueue(l);
        return queue;
    }

    /// <summary>
    /// 初期化する
    /// </summary>
    private void Init()
    {
        _text = LoadTextFile(textFile);
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

        //オブジェクトの表示/非表示を設定する
        nextPageIcon.SetActive(false);

        ReadLine(_pageQueue.Dequeue());
        return true;
    }

    /// <summary>
    /// テキストファイルを読み込む
    /// </summary>
    /// <param name="fname"></param>
    /// <returns></returns>
    private string LoadTextFile(string fname)
    {
        //改行コードは読み込む際に削除しているのでいくら改行しても構わないが、空白はNG
        //↑理由　Windows意外の環境では動かない可能性があるから？なのかな
        TextAsset textasset = Resources.Load<TextAsset>(fname);
        return textasset.text.Replace("\n", "").Replace("\r", "");
    }

}