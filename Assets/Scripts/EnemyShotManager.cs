using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotManager : MonoBehaviour
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
    /// 弾のターゲット
    /// </summary>
    public Transform bulletTarget;  //2021 0511

    //public Enemy2Shot enemy2Shot;
    //public Enemy3Shot enemy3Shot;
    //public Enemy4Shot enemy4Shot;

    //継承先でEnemyの事をここに書く
    void Start()
    {
        //1秒後に１秒毎にShotを繰り返す
        InvokeRepeating("Shot", 1.0f, 1.0f);
        //ここのコードをEnemyMoveのPlayerTagで発見したらShotを繰り出すコードに変更したい
    }

    void Update()
    {
        //2021 0511:bulletTargetの方向に弾が向くようになった 
        if (bulletTarget)
        {
            var direction = bulletTarget.transform.position - transform.position;
            direction.y = 0;

            var lookRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);
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
        //Destroy(BulletsObject.gameObject, 2);

        //Enemy2ShotスクリプトのEnemy2ShotDestroy()を呼び出す //Updataに書いた方が良いかも
        //enemy2Shot.Enemy2ShotDestroy();
        //enemy3Shot.Enemy3ShotDestroy();
        //enemy4Shot.Enemy4ShotDestroy();

        //ゲームオブジェクトの方が良いかも
    }
}