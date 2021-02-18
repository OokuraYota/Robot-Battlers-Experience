using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 必殺技【ハリケーン】の管理
/// </summary>
public class SpecialHurricaneManager : MonoBehaviour
{
    /// <summary>
    /// 変化量
    /// </summary>
    [SerializeField]
    public float amountOfChange;

    public TimelineHurricane timelineHurricane;

    //public ParticleSystem particleSystem;

    public void Start()
    {
        //最初は非アクティブ
        this.gameObject.SetActive(false);
    }

    public void Update()
    {
        HurricaneMoveGo();
    }

    /// <summary>
    /// 必殺技ハリケーンの移動
    /// </summary>
    public void HurricaneMove()
    {
        //if (timelineHurricane.timelineHurricaneBool == true)
        //{
            this.gameObject.SetActive(true);
            //2021 02 19
            Debug.Log("<color=green>アクティブに</color>");

            /*particleSystem.Play();
            //2021 02 19
            Debug.Log("<color=green>パーティクルシステム開始</color>");*/

            //2021 02 19
            Debug.Log("<color=purple>Hurricane前進</color>");

        //Z方向（奥に行ってほしいから）
        //this.gameObject.transform.position += new Vector3(0, 0, amountOfChange * Time.deltaTime);
        //}
    }

    public void HurricaneMoveGo()
    {
        //2021 02 19
        Debug.Log("<color=white>Hurricane前進</color>");

        //Z方向（奥に行ってほしいから）
        this.gameObject.transform.position += new Vector3(0, 0, amountOfChange * Time.deltaTime);
    }
}
