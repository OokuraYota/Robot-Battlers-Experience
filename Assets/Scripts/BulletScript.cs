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

    void Start()
    {
        
    }

    void Update()
    {
        colliderAttack();
        Debug.Log("7");
    }

    private void colliderAttack()
    {
        throw new NotImplementedException();
        Debug.Log("6");
    }

    void colliderAttack(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("1");
            GameObject bulletObjects = Instantiate(bulletObject) as GameObject;

            Debug.Log("2");
            Vector3 force;

            Debug.Log("3");
            force = this.gameObject.transform.forward * attackTimingTime;

            Debug.Log("4");
            //Rigidbodyに力を加えて発射
            bulletObject.GetComponent<Rigidbody>().AddForce(force);

            Debug.Log("5");
            //弾の位置を調整
            bulletObject.transform.position = muzzle.position;
        }
    }
}
