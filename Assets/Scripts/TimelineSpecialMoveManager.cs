using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityStandardAssets.Vehicles.Aeroplane;

/// <summary>
/// Timelineの必殺技関係を管理
/// </summary>
public class TimelineSpecialMoveManager : MonoBehaviour
{
    //ここにインスペクター上であらかじめ複数のタイムラインアセットをセット
    [SerializeField]
    private PlayableDirector playableDirector;

    Vector3 PlayerPosition;

    Vector3 PlayerRotation;

    Vector3 CameraPosition;

    Vector3 CameraRotation;

    /// <summary>
    /// Play画面のカメラのちゃんとした位置 2020/01/28
    /// </summary>
    [SerializeField]
    public Vector3 CameraPlayPosition;

    /// <summary>
    /// Play画面のカメラのちゃんとした角度 2020/01/28
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

    public SpecialHurricaneManager specialHurricaneManager;

    public EnemyBossAppears enemyBossAppears;

    void Update()
    {
        if (enemyBossAppears.TimelineButtonPermit == true)
        {
            Debug.Log("<color=blue>TimelineButtonを押していい許可が降りました。</color>");
            //もし、キーボードのGを押したら
            if (Input.GetKeyDown(KeyCode.G))
            {
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
            }
        }
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

            transform.position = PlayerPosition;
            Debug.Log("Playerの現在の位置は" + PlayerPosition);
            transform.eulerAngles = PlayerRotation;
            Debug.Log("Playerの現在の角度は" + PlayerRotation);

            /*transform.position = CameraPosition;
            Debug.Log("Cameraの現在の位置は" + CameraPosition);
            transform.eulerAngles = CameraRotation;
            Debug.Log("Cameraの現在の角度は" + CameraRotation);*/

            ///
            /*camera.transform.position = CameraPosition;
            Debug.Log("Cameraの現在位置は" + CameraPosition);
            camera.transform.eulerAngles = CameraRotation;
            Debug.Log("Cameraの現在の角度は" + CameraRotation);*/

            camera.transform.position = CameraPlayPosition;
            Debug.Log("Cameraの現在の位置は" + CameraPlayPosition);
            camera.transform.eulerAngles = CameraPlayRotation;
            Debug.Log("Cameraの現在の角度は" + CameraPlayRotation);


            TimelineEnd = true;
            //2021 02 19
            Debug.Log("<color=yellow>Timelineが終わりました</color>");

            timelineHurricane.timelineHurricaneBool = true;
            //2021 02 19
            Debug.Log("<color=yellow>TimelineHurricaneをtureにしました。</color>");

            specialHurricaneManager.HurricaneMove();
        }
    }

    void OnDisable()
    {
        //コンポーネントが非アクティブになったときに呼ばれる
        playableDirector.stopped -= OnPlayableDirectorStopped;
    }

}
