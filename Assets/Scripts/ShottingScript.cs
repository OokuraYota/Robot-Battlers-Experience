﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShottingScript : MonoBehaviour
{
    /// <summary>
    /// 攻撃の速度
    /// </summary>
    [SerializeField]
    float attackTimingTime = 5.0f;

    /// <summary>
    /// 弾のゲームオブジェクト
    /// </summary>
    [SerializeField]
    GameObject bulletObject = null;

    /// <summary>
    /// 玉の発射口の位置
    /// </summary>
    [SerializeField]
    Transform muzzle = null;

    public EnemyMove enemyMove;



    void Start()
    {
        //1秒後に１秒毎にShotを繰り返す
        InvokeRepeating("Shot", 1.0f, 1.0f);
        //ここのコードをEnemyMoveのPlayerTagで発見したらShotを繰り出すコードに変更したい
    }

    void Update()
    {
        if (enemyMove.life == 0)
        {
            CancelInvoke("Shot");
        }
    }

    public void Shot()
    {
        //Instantiate(生成するオブジェクト,位置,回転)　オブジェクトを指定された位置、回転で生成する
        GameObject BulletsObject = Instantiate(bulletObject.gameObject, transform.position, Quaternion.identity);
        Vector3 Force;  //弾にかける力
        Force = transform.forward * 400; //弾にかける力を重工の前方向に設定する
        BulletsObject.GetComponent<Rigidbody>().AddForce(Force); //弾に力をかける



        //弾を完全に削除します。（Immediate = 即座）
        Destroy(BulletsObject.gameObject, 2);
    }



    /*void colliderJudgment(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            GameObject bulletObjects = Instantiate(bulletObject) as GameObject;

            Vector3 force;

            force = this.gameObject.transform.forward * attackTimingTime;

            //Rigidbodyに力を加えて発射
            bulletObject.GetComponent<Rigidbody>().AddForce(force);

            //弾の位置を調整
            bulletObject.transform.position = muzzle.position;
        }
    }*/
}
