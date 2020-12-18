using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

/// <summary>
/// Timelineの必殺技関係を管理
/// </summary>
public class TimelineSpecialMoveManager : MonoBehaviour
{
    //ここにインスペクター上であらかじめ複数のタイムラインアセットをセット
    [SerializeField]
    private PlayableDirector playableDirector;

    /*public void Update()
    {
        OnClick();
    }*/

    /// <summary>
    /// クリックした時Timelineを再生する
    /// </summary>
    /*public void OnClick()
    {
        Debug.Log("必殺技Buttonが押されました");
        playableDirector.Play();
    }*/

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("必殺技Buttonが押されました");
            playableDirector.Play();
        }   
    }

    /*public void Start()
    {
        this.playableDirector = this.GetComponent<PlayableDirector>();   
    }

    //イベント再生メソッド
    void EventPlay(int id)
    {
        switch (id)
        {
            case 1:
                //再生したいTimelineをPlayableDirectorに再生させる
                this.playableDirector.Play();
                break;
            //case 2:
        }
    }*/

}
