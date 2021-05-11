using System.Collections;
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

    /// <summary>
    /// 弾のターゲット
    /// </summary>
    public Transform bulletTarget;  //2021 0511

    public EnemyMove enemyMove;

    /// <summary>
    /// プレイヤーの機体
    /// </summary>
    //public Player playerRobot;   //20210511

    //public Enemy2 enemy2;
    //public Enemy3 enemy3;
    //public Enemy4 enemy4;

    void Start()
    {
        //1秒後に１秒毎にShotを繰り返す
        InvokeRepeating("Shot", 1.0f, 1.0f);
        //ここのコードをEnemyMoveのPlayerTagで発見したらShotを繰り出すコードに変更したい

        //2021 0511 ↓下記のコードがなくても弾はbulletTargetの方向に向く
        //bulletTarget.transform.position = new Vector3(0, 2f, 4.5f);
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

        //bulletTargetのところに、弾が向くようになった。2021 0511
        //ここを消せば、元に戻る。
        /*Vector3 relativePos = bulletTarget.position - transform.position ;//どんどんbulletTargetのx座標が-になっている
        
        Quaternion look = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = look;

        Debug.Log("bulletObjectの位置は :" + bulletObject.transform.position);
        Debug.Log("bulletTargetの位置は :" + bulletTarget.transform.position);*/

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
        //Destroy(BulletsObject.gameObject, 2); 2021 02 11

        ShotDestroy(); //2021 02 11
    }

    public void ShotDestroy()
    {
        if (enemyMove.life <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Enemyの弾を削除しました。");
        }
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
