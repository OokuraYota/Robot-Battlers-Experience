using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4Shot : EnemyShotManager
{
    public Enemy4 enemy4;
    public GameObject enemy4Gun;

    public void Start()
    {
        //🔵秒後に●秒毎にShotを繰り返す
        //InvokeRepeating("Shot", 🔵f, ●f);

        //3.0秒後、1.9秒ごとにShotを繰り返す
        InvokeRepeating("Shot", 3.0f, 1.9f);
    }
    public void Enemy4ShotDestroy()
    {
        Debug.Log("Enemy4のlifeが0以下になったので、銃自体を削除します");
        enemy4Gun.SetActive(false);
    }
}
