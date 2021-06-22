using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosShottingScript : MonoBehaviour
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

    /// <summary>
    /// 敵のボス
    /// </summary>
    public EnemyBos enemyBos;

    /// <summary>
    /// 弾のターゲット
    /// </summary>
    public Transform bulletTarget;

    void Start()
    {
        //1秒後に１秒毎にShotを繰り返す
        InvokeRepeating("Shot", 1.0f, 1.0f);
    }

    void Update()
    {
        //bulletTargetの方向に弾が向くようになった 
        if (bulletTarget)
        {
            var direction = bulletTarget.transform.position - transform.position;
            direction.y = 0;
            var lookRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);
        }

        if (enemyBos.life == 0)
        {
            CancelInvoke("Shot");
        }
    }

    public void Shot()
    {
        //Instantiate(生成するオブジェクト,位置,回転)　オブジェクトを指定された位置、回転で生成する
        GameObject BulletsObject = Instantiate(bulletObject.gameObject, muzzle.transform.position, Quaternion.identity);
        Vector3 Force;  //弾にかける力
        Force = transform.forward * 400; //弾にかける力を重工の前方向に設定する
        BulletsObject.GetComponent<Rigidbody>().AddForce(Force); //弾に力をかける

        BosShotDestory();
    }

    public void BosShotDestory()
    {
        if (enemyBos.life <= 0)
        {
            Debug.Log("EnemyBosのlifeが0以下になったので銃自体を削除します");
            Destroy(this.gameObject);
        }
    }
}