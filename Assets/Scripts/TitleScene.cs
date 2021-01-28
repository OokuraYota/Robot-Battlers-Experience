using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScene : MonoBehaviour
{
    public void StartButton()
    {
        //スタートボタンを押したら、次のSceneに遷移する。
        SceneManager.LoadScene("ViewoftheworldScene");
    }
}


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    //スタートボタンを押したら実行する
    public void StartGame()
    {
        //ゲームクリア条件・操作方法のSceneに移動するようにする。
        SceneManager.LoadScene("OperationExplanation");

        /*Button MenuButton = GetComponent<Button>();  //対象のボタン
        MenuButton.animator.SetTrigger("StartButton");
    } 
}*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private void Start()
    {
        {
            var button = GetComponent<Button>();

            //Buttonを押したときのリスナーを設置
            button.onClick.AddListener(() =>
            {
                //シーンの遷移の際にはSceneManagerを使用する
                SceneManager.LoadScene("MainScene");
            });

            ////button.onClick.AddListener()に『ラムダ式』を渡しています。
            ///ラムダ式とは、無名関数（名前のついていない関数）を表現する式の事で、その場で定義してすぐ関数として使えるのでとても便利です。
            ///ちなみにAddListener()にラムダ式ではなく普通のメソッドを渡すことも可能です。

        }
    }
}*/
