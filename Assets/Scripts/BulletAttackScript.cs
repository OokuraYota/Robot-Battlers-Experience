using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttackScript : MonoBehaviour
{
    public Player player;

    //public float DamageValue;

    void Start()
    {
        player = GetComponent<Player>();
    }

    /// <summary>
    /// オブジェクト同士が重なった『瞬間』に呼び出される
    /// </summary>
    /// <param name="other">当たったColliderオブジェクトの情報</param>
    private void OnTriggerEnter(Collider other)
    {
        //もし、検知したオブジェクトに『CollidionDetector』が付いていないなら呼び出す
        if (!other.CompareTag("CollisionDetector"))
        {
            //関数名：OnTriggerEnter
            //戻り値：なし
            //引数：Collider:当たったColliderオブジェクトの情報
            //内容：オブジェクト同士が重なった瞬間に呼び出される

            Debug.Log("BulletPrefabが" + other.name + "Colliderに重なった！");
            //Debug.Log("") → Swordが + EnemyのBox + Colliderに重なった
        }
    }

    /// <summary>
    /// オブジェクト同士が重なっている『間』呼び出される
    /// </summary>
    /// <param name="other">当たったColliderオブジェクトの情報</param>
    private void OnTriggerStay(Collider other)
    {
        //もし、検知したオブジェクトに『CollidionDetector』が付いていないなら呼び出す
        if (!other.CompareTag("CollisionDetector"))
        {
            //関数名：OnTriggerStay
            //戻り値：なし
            //引数：Collider:当たったColliderオブジェクトの情報
            //オブジェクト同士が重なっている間呼び出される

            Debug.Log("BulletPrefabが" + other.name + "Colliderに重なっています！");
        }
    }

    /// <summary>
    /// 重なり合ったオブジェクト同士が『離れた瞬間』呼び出される
    /// </summary>
    /// <param name="other">当たったColliderオブジェクトの情報</param>
    private void OnTriggerExit(Collider other)
    {
        //もし、検知したオブジェクトに『CollidionDetector』が付いていないなら呼び出す
        if (!other.CompareTag("CollisionDetector"))
        {
            //関数名：OnTriggerExit
            //戻り値：なし
            //引数：Collider:当たったColliderオブジェクトの情報
            //内容：重なり合ったオブジェクト同士が離れた瞬間呼び出される

            Debug.Log("BulletPrefabが" + other.name + "Colliderから、今離れました！");


            //player.Damage(1);

            //other.gameObject.GetComponent<Player>().Damage(1.0f);  本当のやつ

            if (other.gameObject.GetComponent<Player>() == true)//2021 02 09
            {
                other.gameObject.GetComponent<Player>().Damage(1.0f);
            }


            //if (other.gameObject.GetComponent<EnemyMove>() == true)

            //DamageValue = player.GetComponent<Player>().Damage(1.0f);
            //Debug.Log("PlayerのHPは" + player.life);*/
        }
    }
}
