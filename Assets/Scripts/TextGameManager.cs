﻿using System.Collections;
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

    private const char SEPARATE_MAIN_START = '「';
    private const char SEPARATE_MAIN_END = '」';

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
    //private string _text = "大倉「こんにちは\nこんばんわ\nおはようございます」&大倉「これはテキストの表示サンプルです」&芝間「こんにちは」";

    [SerializeField]
    private GameObject nextpageImage;


    //2021 01 21
    // パラメーターを追加
    private const char SEPARATE_COMMAND = '!';
    private const char COMMAND_SEPARATE_PARAM = '=';
    private const string COMMAND_BACKGROUND = "background";
    private const string COMMAND_SPRITE = "_sprite";
    private const string COMMAND_COLOR = "_color";
    [SerializeField]
    private Image backgroundImage;
    [SerializeField]
    private string spritesDirectory = "Sprites/";

    // パラメーターを変更
    //private string _text =
    //"!background_sprite=\"background_sprite1\"&みにに「Hello,World!」&みにに「これはテキスト表示のサンプルです」&!background_sprite=\"background_sprite2\"!background_color=\"255,0,255\"&名無し「こんにちは！」";


    // パラメーターを追加
    private const string COMMAND_CHARACTER_IMAGE = "charaimg";
    private const string COMMAND_SIZE = "_size";
    private const string COMMAND_POSITION = "_pos";
    private const string COMMAND_ROTATION = "_rotate";
    private const string CHARACTER_IMAGE_PREFAB = "CharacterImage";
    [SerializeField]
    private GameObject characterImages;
    [SerializeField]
    private string prefabsDirectory = "Prefabs/";
    private List<Image> _charaImageList = new List<Image>();

    // パラメーターを追加
    [SerializeField]
    private string textFile = "Texts/Scenario";

    // パラメーターを変更
    private string _text = "";

    // パラメーターを変更
    /*private string _text =
           "!background_sprite=\"background_sprite1\"!charaimg_sprite=\"polygon\"=\"background_sprite2\"" +
           "!charaimg_size=\"polygon\"=\"500, 500, 1\"&みにに「Hello,World!」&みにに「これはテキスト表示のサンプルです」" +
           "&!background_sprite=\"background_sprite2\"!background_color=\"255,0,255\"!charaimg_pos=\"polygon\"=\"-500, 500, 0\"&名無し「こんにちは！」";
           */

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
        if (_charQueue.Count <= 0)
        {
            nextpageImage.SetActive(true);
            return false;
        }

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

        // 最初が「!」だったら
        if (text[0].Equals(SEPARATE_COMMAND))
        {
            ReadCommand(text);
            ShowNextPage();
            return;
        }

        //'『'の位置で文字列を分ける
        string[] ts = text.Split(SEPARATE_MAIN_START);

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
        nextpageImage.SetActive(true);
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

        //オブジェクトの表示/非表示を設定する。
        nextpageImage.SetActive(false);

        ReadLine(_pageQueue.Dequeue());
        return true;
    }


    //2021 01 21
    /**
      * 背景の設定
      */
    // メソッドを変更
    private void SetBackgroundImage(string cmd, string parameter)
    {
        cmd = cmd.Replace(COMMAND_BACKGROUND, "");
        SetImage(cmd, parameter, backgroundImage);
    }
    /**
     * コマンドの読み出し
     */
    /*private void ReadCommand(string cmdLine)
    {
        // 最初の「!」を削除する
        cmdLine = cmdLine.Remove(0, 1);
        Queue<string> cmdQueue = SeparateString(cmdLine, SEPARATE_COMMAND);
        foreach (string cmd in cmdQueue)
        {
            // 「=」で分ける
            string[] cmds = cmd.Split(COMMAND_SEPARATE_PARAM);
            // もし背景コマンドの文字列が含まれていたら
            if (cmds[0].Contains(COMMAND_BACKGROUND))
                SetBackgroundImage(cmds[0], cmds[1]);
        }
    }*/

    // メソッドを変更
    private void ReadCommand(string cmdLine)
    {
        cmdLine = cmdLine.Remove(0, 1);
        Queue<string> cmdQueue = SeparateString(cmdLine, SEPARATE_COMMAND);
        foreach (string cmd in cmdQueue)
        {
            string[] cmds = cmd.Split(COMMAND_SEPARATE_PARAM);
            if (cmds[0].Contains(COMMAND_BACKGROUND))
                SetBackgroundImage(cmds[0], cmds[1]);
            if (cmds[0].Contains(COMMAND_CHARACTER_IMAGE))
                SetCharacterImage(cmds[1], cmds[0], cmds[2]);
        }
    }


    private void SetImage(string cmd, string parameter, Image image)
    {
        cmd = cmd.Replace(" ", "");
        parameter = parameter.Substring(parameter.IndexOf('"') + 1, parameter.LastIndexOf('"') - parameter.IndexOf('"') - 1);
        switch (cmd)
        {
            case COMMAND_SPRITE:
                image.sprite = LoadSprite(parameter);
                break;
            case COMMAND_COLOR:
                image.color = ParameterToColor(parameter);
                break;
            case COMMAND_SIZE:
                image.GetComponent<RectTransform>().sizeDelta = ParameterToVector3(parameter);
                break;
            case COMMAND_POSITION:
                image.GetComponent<RectTransform>().anchoredPosition = ParameterToVector3(parameter);
                break;
            case COMMAND_ROTATION:
                image.GetComponent<RectTransform>().eulerAngles = ParameterToVector3(parameter);
                break;
        }
    }

    // メソッドを追加
    /**
    * スプライトをファイルから読み出し、インスタンス化する
*/
    private Sprite LoadSprite(string name)
    {
        return Instantiate(Resources.Load<Sprite>(spritesDirectory + name));
    }

    /**
* パラメーターから色を作成する
*/
    private Color ParameterToColor(string parameter)
    {
        string[] ps = parameter.Replace(" ", "").Split(',');
        if (ps.Length > 3)
            return new Color32(byte.Parse(ps[0]), byte.Parse(ps[1]),
                                            byte.Parse(ps[2]), byte.Parse(ps[3]));
        else
            return new Color32(byte.Parse(ps[0]), byte.Parse(ps[1]),
                                            byte.Parse(ps[2]), 255);
    }



    // メソッドを追加
    /**
    * 立ち絵の設定
*/
    private void SetCharacterImage(string name, string cmd, string parameter)
    {
        cmd = cmd.Replace(COMMAND_CHARACTER_IMAGE, "");
        name = name.Substring(name.IndexOf('"') + 1, name.LastIndexOf('"') - name.IndexOf('"') - 1);
        Image image = _charaImageList.Find(n => n.name == name);
        if (image == null)
        {
            image = Instantiate(Resources.Load<Image>(prefabsDirectory + CHARACTER_IMAGE_PREFAB), characterImages.transform);
            image.name = name;
            _charaImageList.Add(image);
        }
        SetImage(cmd, parameter, image);
    }

    /**
    * パラメーターからベクトルを取得する
*/
    private Vector3 ParameterToVector3(string parameter)
    {
        string[] ps = parameter.Replace(" ", "").Split(',');
        return new Vector3(float.Parse(ps[0]), float.Parse(ps[1]), float.Parse(ps[2]));
    }

    /**
     * テキストファイルを読み込む
     */
    private string LoadTextFile(string fname)
    {
        TextAsset textasset = Resources.Load<TextAsset>(fname);
        return textasset.text.Replace("\n", "").Replace("\r", "");
    }

}
