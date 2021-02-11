using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Shot : EnemyShotManager
{
    public Enemy2 enemy2;
    public GameObject enemy2Gun;

    public void Enemy2ShotDestroy()
    {
        if (enemy2.life <= 0)
        {
            Debug.Log("Enemy2のlifeが0以下になったので、銃自体を非表示にします");
            enemy2Gun.SetActive(false);
        }
    }
}
