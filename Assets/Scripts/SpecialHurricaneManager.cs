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

    public EnemyBos enemyBos;

    public Vector3 HurricanePosition;

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
        //Timelineが終わったらtrueにしてもらい、Updateの中のHurricaneMoveGo()
        //のおかげで前進するように見せている

        this.gameObject.SetActive(true);
        //2021 02 19
        Debug.Log("<color=green>アクティブに</color>");

        //コルーチンを実装
        StartCoroutine("WaitingTimeDamage");
    }

    public void HurricaneMoveGo()
    {
        //2021 02 19
        Debug.Log("<color=white>Hurricane前進</color>");

        //Z方向（奥に行ってほしいから）
        this.gameObject.transform.position += new Vector3(0, 0, amountOfChange * Time.deltaTime);
    }

    public IEnumerator WaitingTimeDamage()
    {
        yield return new WaitForSeconds(3.5f);
        Debug.Log("3.5秒待ったら");

        HurricaneDamage();
    }

    public void HurricaneDamage()
    {
        Debug.Log("<color=yellow>5ダメージ</color>");
        enemyBos.Damage(5.0f);

        if (this.gameObject.transform.position.z >= 55)
        {
            //最初から決めて置いたpositionに置き換える
            this.gameObject.transform.position = HurricanePosition;
            Debug.Log("<color=green>" + this.gameObject.transform.position + "</color>");

            this.gameObject.SetActive(false);
        }
    }
}
