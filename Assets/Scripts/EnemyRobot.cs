using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletScript : MonoBehaviour
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
        InvokeRepeating("Shot", 1, 1); //1秒後に1秒ごとにShotを繰り出す
    }

    void Update()
    {
        
    }

    void Shot()
    {
        GameObject BulletsObject = Instantiate(bulletObject.gameObject, transform.position, transform.rotation);
        Vector3 Force;  //弾にかける力
        Force = transform.forward * 400; //弾にかける力を重工の前方向に設定する
        BulletsObject.GetComponent<Rigidbody>().AddForce(Force); //弾に力をかける
       
        //弾を完全に削除します。（Immediate = 即座）
        Destroy(BulletsObject.gameObject,2);
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
