using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    Transform createBulletTrans = null;

    /// <summary>
    /// 攻撃に入るまでの時間？
    /// </summary>
    float startAttackTime = 0.0f;

    //Vector3 moveDir = Vector3.zero;
    //Vector3 startMovePos = Vector3.zero;

    /*public void OnAttack()
    {
        GameObject bulletInstance = Instantiate(bulletPrefab);
        Bullet bullet = bulletInstance.GetComponent<Bullet>();
        bullet.StartMove(this, createBulletTrans.position, SelfTransform.forward);
    }*/
}
