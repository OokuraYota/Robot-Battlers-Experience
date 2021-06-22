using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class EnemyBossAppears : MonoBehaviour
{
    public EnemyBos enemyBos;
    public EnemyMove enemy;
    public Enemy2 enemy2;
    public Enemy3 enemy3;
    public Enemy4 enemy4;
    public BosTimelineScript bosTimelineScript;
    [SerializeField]
    public GameObject BosGauge;
    [SerializeField]
    public GameObject TimelineButton;
    public bool TimelineButtonPermit = false;

    /// <summary>
    /// 1回だけ呼び出い処理
    /// </summary>
    bool isCalledOne = false;

    public void Start()
    {
        BosGauge.SetActive(false);
        TimelineButton.SetActive(false);
    }

    public void Update()
    {
        TheBossAppears();
    }

    /// <summary>
    /// 敵4体が全滅したら、Bossを表示する
    /// </summary>
    public void TheBossAppears()
    {
        if (!isCalledOne && enemy.life <= 0 && enemy2.life <= 0 && enemy3.life <= 0 && enemy4.life <= 0)
        {
            //Timelineを再生する。
            BosTimelineStartCoroutine();
            isCalledOne = true;
            Debug.Log("<color=red>Bossが登場します！！！</color>");
            BosTimelineWaitForSeconds();
        }
    }

    public void BosTimelineStartCoroutine()
    {
        Debug.Log("最後の敵が爆発してからTimelineを再生したいので、少し待ちます");
        StartCoroutine("BosTimelineStart");
    }

    public IEnumerator BosTimelineStart()
    {
        Debug.Log("0.4秒経過してから");
        //3秒経過してから
        yield return new WaitForSeconds(0.4f);
        //2021 02 10 タイムラインを再生する
        bosTimelineScript.BosTimelineStart();
    }


    public void BosTimelineWaitForSeconds()
    {
        //コルーチンを呼び出す
        Debug.Log("EnemyBosSetActiveTimeを呼び出しています");
        StartCoroutine("EnemyBosSetActiveTime");
    }

    private IEnumerator EnemyBosSetActiveTime()
    {
        Debug.Log("3.3秒経過してから実際のBosをアクティブにする");
        //3秒経過してから
        yield return new WaitForSeconds(3.3f);

        enemyBos.gameObject.SetActive(true);

        BosGauge.SetActive(true);
        Debug.Log("ボスのゲージ表示");

        TimelineButton.SetActive(true);

        //EnemyBosが表示されたら、許可が降りる
        TimelineButtonPermit = true;
    }
}
