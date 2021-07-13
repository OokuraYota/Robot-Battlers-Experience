using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class EnemyRobot : MonoBehaviour
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

    void Update()
    {
        colliderAttack();
    }

    private void colliderAttack()
    {
        throw new NotImplementedException();
    }

    void colliderAttack(Collider collider)
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
    }
}