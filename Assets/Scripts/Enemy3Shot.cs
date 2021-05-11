using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Shot : EnemyShotManager
{
    public Enemy3 enemy3;
    public GameObject enemy3Gun;

    void Start()
    {
        //🔵秒後に●秒毎にShotを繰り返す
        //InvokeRepeating("Shot", 🔵f, ●f);

        //2.5秒後、1.6秒ごとにShotを繰り返す
        InvokeRepeating("Shot", 2.5f, 1.6f);
    }

    public void Enemy3ShotDestroy()
    {
        if (enemy3.life <= 0)
        {
            Debug.Log("Enemy3のlifeが0になったので、銃自体を削除します");
            //enemy3Gun.SetActive(false);
        }
    }
}
