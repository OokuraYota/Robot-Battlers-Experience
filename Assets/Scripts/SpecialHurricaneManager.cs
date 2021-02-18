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


    public void Start()
    {
        
    }

    public void Update()
    {
        HurricaneMove();
    }

    /// <summary>
    /// 必殺技ハリケーンの移動
    /// </summary>
    public void HurricaneMove()
    {
        //Time.deltaTimeは1フレーム前からの経過時間を表してくれているから
        //変化量*時間の形にすることが出来た。
        //これで、時間単位で移動してくれるようになった。

        //Z方向（奥に行ってほしいから）
        this.gameObject.transform.position += new Vector3(0,0,amountOfChange * Time.deltaTime);
    }
}
