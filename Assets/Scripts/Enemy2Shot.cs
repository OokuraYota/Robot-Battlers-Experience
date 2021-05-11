using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Shot : EnemyShotManager
{
    public Enemy2 enemy2;
    //public GameObject enemy2Gun;


    void Start()
    {
        //🔵秒後に●秒毎にShotを繰り返す
        //InvokeRepeating("Shot", 🔵f, ●f);

        //2.0秒後、1.3秒ごとにShotを繰り返す。
        InvokeRepeating("Shot", 2.0f, 1.2f);
    }


    public void Enemy2ShotDestroy()
    {
        if (enemy2.life <= 0)
        {
            Debug.Log("Enemy2のlifeが0以下になったので、銃自体を非表示にします");
            //enemy2Gun.SetActive(false);
        }
    }
}
