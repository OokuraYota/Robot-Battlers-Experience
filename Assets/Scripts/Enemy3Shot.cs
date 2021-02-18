using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Shot : EnemyShotManager
{
    public Enemy3 enemy3;
    public GameObject enemy3Gun;

    public void Enemy3ShotDestroy()
    {
        if (enemy3.life <= 0)
        {
            Debug.Log("Enemy3のlifeが0になったので、銃自体を削除します");
            //enemy3Gun.SetActive(false);
        }
    }
}
