using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4Shot : EnemyShotManager
{
    public Enemy4 enemy4;
    public GameObject enemy4Gun;

    public void Enemy4ShotDestroy()
    {
        Debug.Log("Enemy4のlifeが0以下になったので、銃自体を削除します");
        enemy4Gun.SetActive(false);
    }
}
