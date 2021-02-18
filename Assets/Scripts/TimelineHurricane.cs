using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineHurricane : MonoBehaviour
{
    [SerializeField]
    public TimelineSpecialMoveManager timelineSpecialMoveManager;

    /// <summary>
    /// TimelineのHurricaneが終わったかの判定
    /// </summary>
    public bool timelineHurricaneBool = false;

    public void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void Update()
    {
        TimelineStartWind();
        //TimelineEndWind();
    }

    /// <summary>
    /// Timelineが始まったら、Windをアクティブにする
    /// </summary>
    public void TimelineStartWind()
    {
        
        if (timelineSpecialMoveManager.TimelineStart == true)
        {
            //2021 02 19
            Debug.Log("<color=yellow>Windをアクティブにします</color>");
            this.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Timelineが終わったら、Windを非アクティブにする
    /// </summary>
    public void TimelineEndWind()
    {
        if (timelineSpecialMoveManager.TimelineEnd == true)
        {
            //2021 02 19
            Debug.Log("<color=yellow>TimelineHurricaneをtureにしました。</color>");
            timelineHurricaneBool = true;
        }
    }
}
