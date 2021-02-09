using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Playables;

/// <summary>
/// ボス敵が上から降ってくるTimelineの管理
/// </summary>
public class BosTimelineScript : MonoBehaviour
{
    //インスペクター上であらかじめタイムラインアセットをセットする
    [SerializeField]
    private PlayableDirector BosTimeline;

    [SerializeField]
    public GameObject BosTimelineCanvas;

    [SerializeField]
    public GameObject BosTimelineObject;

    /// <summary>
    /// Play画面のカメラのちゃんとした位置 2020/01/28
    /// </summary>
    //[SerializeField]
    //public Vector3 CameraPlayPosition;

    /// <summary>
    /// Play画面のカメラのちゃんとした角度 2020/01/28
    /// </summary>
    //[SerializeField]
    //public Vector3 CameraPlayRotation;

    /// <summary>
    /// BosTimeline時のカメラの位置
    /// </summary>
    //[SerializeField]
    //public Vector3 BosTimelineCameraPosition;

    /// <summary>
    /// BosTimeline時のカメラの角度
    /// </summary>
    //[SerializeField]
    //public Vector3 BosTimelineCameraRotation;

    [SerializeField] GameObject PlayCamera;

    [SerializeField] GameObject BosTimelineCamera;

    public void Start()
    {
        //Play時カメラ格納
        PlayCamera = GameObject.Find("Main Camera");
        //Bos登場Timeline用カメラ格納
        BosTimelineCamera = GameObject.Find("BosTimelineCamera");

        //Bos登場用のカメラを非アクティブにする
        BosTimelineCamera.SetActive(false);

        //Timeline用のBosObjectは最初非アクティブにする
        BosTimelineObject.SetActive(false);
    }

    public void Update()
    {
        
    }

    /// <summary>
    /// BosTimelineを再生させる
    /// </summary>
    public void BosTimelineStart()
    {


        Debug.Log("BosTimelineが再生されます");
        //タイムラインを再生
        BosTimeline.Play();

        BosTimelineObject.SetActive(true);

        //Play用のカメラからTimeline用のカメラに切り替えます
        PlayCamera.SetActive(false);
        Debug.Log(PlayCamera + "activeSelf :" + PlayCamera.activeSelf);

        BosTimelineCamera.SetActive(true);
        Debug.Log(BosTimelineCamera + "activeSelf :" + BosTimelineCamera.activeSelf);
    }

    /// <summary>
    /// Timelineが終わったかどうかを検知する
    /// </summary>
    /// <param name="aDirector"></param>
    void BosTimelineStopped(PlayableDirector aDirector)
    {
        if (BosTimeline == aDirector)
        {
            Debug.Log("BosTimelineは、" + aDirector.name + "を今停止した");

            BosTimelineCamera.SetActive(false);
            Debug.Log(BosTimelineCamera + "activeSelf :" + BosTimelineCamera.activeSelf);

            PlayCamera.SetActive(true);
            Debug.Log(PlayCamera + "activeSelf :" + PlayCamera.activeSelf);

            //このままだと、真っ黒なままなのでBosTimelineCanvasを消す
            Destroy(BosTimelineCanvas);
            //更に、Timeline用のBosも消す
            Destroy(BosTimelineObject);
        }
    }

    void OnEnable()
    {
        //OnEnable　この関数はオブジェクトが有効/アクティブになったときに呼び出されます。
        BosTimeline.stopped += BosTimelineStopped;
    }

    void OnDisable()
    {
        //コンポーネントが非アクティブになったときに呼ばれる
        BosTimeline.stopped -= BosTimelineStopped;
    }


}
