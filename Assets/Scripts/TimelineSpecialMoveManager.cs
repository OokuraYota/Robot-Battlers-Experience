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

    void Update()
    {
        //もし、キーボードのGを押したら
        if (Input.GetKeyDown(KeyCode.G))
        {
            /* 指定した名前のオブジェクトを存在するすべてのアクティブな
             * オブジェクトの中から探し出して取得する。
             */
            Vector3 PlayerPositon = GameObject.Find("PlayerRobot").transform.position;
            Debug.Log("プレイヤーの位置は : " + PlayerPosition);

            //角度も取得
            Vector3 PlayerRotation = GameObject.Find("PlayerRobot").transform.eulerAngles;
            Debug.Log("プレイヤーの角度は" + PlayerRotation);

            Debug.Log("必殺技Buttonが押されました");
            playableDirector.Play();

            /* Playerの角度も取得して、（カメラも位置と角度）
             * Timelineの再生が終わったら
             * 黄色の遷移的なのが始まって明るくなるころには戻っている
             */
            //transform.position = PlayerPosition;
            //transform.eulerAngles = PlayerRotation;


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
        }
    }

    void OnDisable()
    {
        //コンポーネントが非アクティブになったときに呼ばれる
        playableDirector.stopped -= OnPlayableDirectorStopped;
    }

}
