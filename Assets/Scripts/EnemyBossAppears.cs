using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class EnemyBossAppears : MonoBehaviour
{
    public EnemyBos enemyBos;
    public EnemyMove enemy;

    public Enemy2 enemy2; //2021 02 09

    public Enemy3 enemy3;
    /// <summary>
    /// ２体目の敵
    /// </summary>
    //public EnemyMove enemy2;  //20210208 追加
    //public EnemyMove enemy3;
    //public EnemyMove enemy4;

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

        //もし、isCalledOneがfalseではなく、enmeyの１～４体すべてのlifeが0になったら
        //if (!isCalledOne && enemy.life <= 0 && enemy2.life <= 0 && enemy3.life <= 0 && enemy4.life <= 0)
        /*{
            isCalledOne = true;
            Debug.Log("お茶");
            enemyBos.gameObject.SetActive(true);
        }*/

        if (!isCalledOne && enemy.life <= 0 && enemy2.life <= 0 && enemy3.life <= 0)
        {
            isCalledOne = true;
            Debug.Log("お茶");
            enemyBos.gameObject.SetActive(true);
        }
    }
}
