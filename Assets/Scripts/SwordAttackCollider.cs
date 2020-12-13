using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SwordのBoxColliderとEnemyのBoxColliderの重なり判定
/// </summary>
public class SwordAttackCollider : MonoBehaviour
{
    ////public Player player;

    /*void Start()
    {
        ////player = GetComponent<Player>();
    }*/

    /// <summary>
    /// オブジェクト同士が重なった『瞬間』に呼び出される
    /// </summary>
    /// <param name="other">当たったColliderオブジェクトの情報</param>
    private void OnTriggerEnter(Collider other)
    {
        //関数名：OnTriggerEnter
        //戻り値：なし
        //引数：Collider:当たったColliderオブジェクトの情報
        //内容：オブジェクト同士が重なった瞬間に呼び出される

        Debug.Log("Swordが" + other.name + "Colliderに重なった！");
        //Debug.Log("") → Swordが + EnemyのBox + Colliderに重なった
    }

    /// <summary>
    /// オブジェクト同士が重なっている『間』呼び出される
    /// </summary>
    /// <param name="other">当たったColliderオブジェクトの情報</param>
    private void OnTriggerStay(Collider other)
    {
        //関数名：OnTriggerStay
        //戻り値：なし
        //引数：Collider:当たったColliderオブジェクトの情報
        //オブジェクト同士が重なっている間呼び出される

        Debug.Log("Swordが" + other.name + "Colliderに重なっています！");
    }

    /// <summary>
    /// 重なり合ったオブジェクト同士が『離れた瞬間』呼び出される
    /// </summary>
    /// <param name="other">当たったColliderオブジェクトの情報</param>
    private void OnTriggerExit(Collider other)
    {
        //関数名：OnTriggerExit
        //戻り値：なし
        //引数：Collider:当たったColliderオブジェクトの情報
        //内容：重なり合ったオブジェクト同士が離れた瞬間呼び出される

        Debug.Log("Swordが" + other.name + "Colliderから、今離れました！");

        ////other.gameObject.GetComponent<Player>().Damage(1.0f);
    }
}
