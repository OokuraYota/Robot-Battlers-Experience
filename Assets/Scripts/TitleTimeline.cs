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

    public TimelineHurricane timelineHurricane;

    void Start()
    {
            Debug.Log("<color=blue>TitleTimeline開始</color>");
            //もし、キーボードのGを押したら
            //if (Input.GetKeyDown(KeyCode.G))
            //{
                /* 指定した名前のオブジェクトを存在するすべてのアクティブな
                 * オブジェクトの中から探し出して取得する。
                 */
                Vector3 PlayerPositon = GameObject.Find("PlayerRobot").transform.position;
                Debug.Log("プレイヤーの位置を取得 : " + PlayerPositon);

                //角度も取得
                Vector3 PlayerRotation = GameObject.Find("PlayerRobot").transform.eulerAngles;
                Debug.Log("プレイヤーの角度を取得" + PlayerRotation);

                //Cameraの位置と角度も取得
                /*Vector3 CameraPosition = GameObject.Find("Main Camera").transform.position;
                Debug.Log("カメラの位置を取得" + CameraPosition);*/
                Vector3 CameraPosition = camera.transform.position;
                Debug.Log("プレイヤーの位置を取得" + CameraPosition);

                /*Vector3 CameraRotation = GameObject.Find("Main Camera").transform.eulerAngles;
                Debug.Log("カメラの角度を取得" + CameraRotation);*/
                Vector3 CameraRotation = camera.transform.eulerAngles;
                Debug.Log("カメラの角度を取得" + CameraRotation);


                Debug.Log("必殺技Buttonが押されました");
                playableDirector.Play();

                //2021 02 19
                Debug.Log("<color=blue>Timelineが始まりました</color>");
                TimelineStart = true;

                /* Playerの角度も取得して、（カメラも位置と角度）
                 * Timelineの再生が終わったら
                 * 黄色の遷移的なのが始まって明るくなるころには戻っている
                 */
                //transform.position = PlayerPosition;
                //transform.eulerAngles = PlayerRotation;
            //}
        //} 
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

            /*transform.position = PlayerPosition;
            Debug.Log("Playerの現在の位置は" + PlayerPosition);
            transform.eulerAngles = PlayerRotation;
            Debug.Log("Playerの現在の角度は" + PlayerRotation);

            camera.transform.position = CameraPlayPosition;
            Debug.Log("Cameraの現在の位置は" + CameraPlayPosition);
            camera.transform.eulerAngles = CameraPlayRotation;
            Debug.Log("Cameraの現在の角度は" + CameraPlayRotation);
            */

            TimelineEnd = true;
            //2021 02 19
            Debug.Log("<color=yellow>Timelineが終わりました</color>");

            //timelineHurricane.timelineHurricaneBool = true;
            //2021 02 19
            Debug.Log("<color=yellow>TimelineHurricaneをtureにしました。</color>");

            //20210518
            //次のSceneに遷移する。
            StartTransition();
        }
    }

    void OnDisable()
    {
        //コンポーネントが非アクティブになったときに呼ばれる
        playableDirector.stopped -= OnPlayableDirectorStopped;
    }

    public void StartTransition()
    {
        Debug.Log("遷移を始めます");
        SceneManager.LoadScene("ViewoftheworldScene");
    }
}
