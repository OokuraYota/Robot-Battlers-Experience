using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossAppears : MonoBehaviour
{
    public EnemyBos enemyBos;
    public EnemyMove enemy;

    public void Start()
    {
        
    }

    public void Update()
    {
        TheBossAppears();
    }

    public void TheBossAppears() //敵が死んだら【ボスを表示する】
    {
        //エネミーのlifeが0になったら
        if (enemy.life <= 0)
        {
            //EnemyBosをアクティブにする
            enemyBos.gameObject.SetActive(true);
        }
    }
}
