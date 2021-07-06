using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityStandardAssets.Vehicles.Aeroplane;
using UnityEngine.SceneManagement;

/// <summary>
/// TitleでTimelineを流すためのScript
/// </summary>
public class TitleTimeline : MonoBehaviour
{
    //タイトルのタイムラインが終わったら、名前が表示される → タイムライン終了時にボタンがアクティブになって点滅。それを押すとゲーム開始になる。

    //ここにインスペクター上であらかじめ複数のタイムラインアセットをセット
    [SerializeField]
    private PlayableDirector playableDirector;

    Vector3 PlayerPosition;

    Vector3 PlayerRotation;

    /// <summary>
    /// Play画面のカメラのちゃんとした位置
    /// </summary>
    [SerializeField]
    public Vector3 CameraPlayPosition;

    /// <summary>
    /// Play画面のカメラのちゃんとした角度
    /// </summary>
    [SerializeField]
    public Vector3 CameraPlayRotation;

    //transformは、スクリプトがついているオブジェクトの位置
    //だからシリアライズフィールドとかしてカメラの角度を

    [SerializeField] Camera camera;

    public bool TimelineStart = false;

    //Timelineが終わった判定
    public bool TimelineEnd = false;

    //public TimelineHurricane timelineHurricane;

    /// <summary>
    /// ボタンを押したら、ゲームを開始するオブジェクト
    /// </summary>
    public GameObject StartButton; //2021年 7月6日
    public StartButtonTitle startButtonTitle;

    void Start()
    {
        Debug.Log("<color=blue>TitleTimeline開始</color>");

        Vector3 PlayerPositon = GameObject.Find("PlayerRobot").transform.position;
        Debug.Log("プレイヤーの位置を取得 : " + PlayerPositon);

        //角度も取得
        Vector3 PlayerRotation = GameObject.Find("PlayerRobot").transform.eulerAngles;
        Debug.Log("プレイヤーの角度を取得" + PlayerRotation);

        Vector3 CameraPosition = camera.transform.position;
        Debug.Log("プレイヤーの位置を取得" + CameraPosition);

        Vector3 CameraRotation = camera.transform.eulerAngles;
        Debug.Log("カメラの角度を取得" + CameraRotation);


        Debug.Log("必殺技Buttonが押されました");
        playableDirector.Play();

        //2021 02 19
        Debug.Log("<color=blue>Timelineが始まりました</color>");
        TimelineStart = true;

        //2021年 7月6日 タイムライン終わるまで非表示
        StartButton.SetActive(false);
    }

    void OnEnable()
    {
        //OnEnable　この関数はオブジェクトが有効/アクティブになったときに呼び出されます。
        playableDirector.stopped += OnPlayableDirectorStopped;
    }

    /// <summary>
    /// Timelineが終わったかどうかを検知する
    /// </summary>
    /// <param name="aDirector"></param>
    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (playableDirector == aDirector)
        {
            Debug.Log("PlayableDirectorは、" + aDirector.name + "今停止した");

            TimelineEnd = true;
            //2021 02 19
            Debug.Log("<color=yellow>Timelineが終わりました</color>");

            //timelineHurricane.timelineHurricaneBool = true;
            //2021 02 19
            Debug.Log("<color=yellow>TimelineHurricaneをtureにしました。</color>");

            //次のSceneに遷移する。
            //StartTransition();

            //2021年7月6日
            StartButtonTrue();
        }
    }

    void OnDisable()
    {
        //コンポーネントが非アクティブになったときに呼ばれる
        playableDirector.stopped -= OnPlayableDirectorStopped;
    }

    /*public void StartTransition()
    {
        Debug.Log("遷移を始めます");
        SceneManager.LoadScene("ViewoftheworldScene");
    }*/

    public void StartButtonTrue()
    {
        StartButton.SetActive(true);
    }
}