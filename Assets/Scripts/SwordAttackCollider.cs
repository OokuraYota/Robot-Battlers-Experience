using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackCollider : MonoBehaviour
{
    //剣
    //重なり瞬間判定
    private void OnTriggerEnter(Collider other)
    {
        //関数名：OnTriggerEnter
        //戻り値：なし
        //引数：Collider:当たったColliderオブジェクトの情報
        //内容：オブジェクト同士が重なった瞬間に呼び出される

        Debug.Log("Swordが" + other.name + "Colliderに重なった");
        //Debug.Log("") → Swordが + EnemyのBox + Colliderに重なった
    }

    //重なり中の判定
    private void OnTriggerStay(Collider other)
    {
        //関数名：OnTriggerStay
        //戻り値：なし
        //引数：Collider:当たったColliderオブジェクトの情報
        //オブジェクト同士が重なっている間呼び出される
        Debug.Log(other.name + "Stay");
    }

    //重なり離脱の判定
    private void OnTriggerExit(Collider other)
    {
        //関数名：OnTriggerExit
        //戻り値：なし
        //引数：Collider:当たったColliderオブジェクトの情報
        //内容：重なり合ったオブジェクト同士が離れた瞬間呼び出される
        Debug.Log(other.name + "Exit");
    }
}
