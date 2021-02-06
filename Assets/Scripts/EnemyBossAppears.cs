using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossAppears : MonoBehaviour
{
    public EnemyBos enemyBos;
    public EnemyMove enemy;

    /// <summary>
    /// 1回だけ呼び出い処理
    /// </summary>
    bool isCalledOne = false;

    public void Start()
    {

    }

    public void Update()
    {
        TheBossAppears();
    }

    public void TheBossAppears() //敵が死んだら【ボスを表示する】
    {
        /*if (enemy.life <= 0)
        {
            Debug.Log("お茶");
            //EnemyBosをアクティブにする
            enemyBos.gameObject.SetActive(true);
        }*/

        //もし、isCalledOneがfalseじゃない時
        /*if(!isCalledOne)
        {
            isCalledOne = true;
            //もし、enemy.lifeが0以下なら
            if (enemy.life <= 0)
            {
                Debug.Log("お茶");
                enemyBos.gameObject.SetActive(true);
            }
        }*/

        if (!isCalledOne && enemy.life <= 0)
        {
            isCalledOne = true;
            Debug.Log("お茶");
            enemyBos.gameObject.SetActive(true);
        }
    }
}
