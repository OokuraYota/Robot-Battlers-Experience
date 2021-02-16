using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 対戦相手の女性に接触すると何かを表示するようにするスクリプト
/// </summary>
public class XXXXX : MonoBehaviour
{
    public TheMomentYouTouchActive theMomentYouTouchActive;

    public void Update()
    {
        
    }

    /// <summary>
    /// 当たり判定
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)//衝突した相手の情報がCollision型で送られてくる
    {
        //この関数はRigidbodyとCollider関係のコンポーネントを持っている
        //オブジェクトが衝突した場合、自動的に呼び出される。

        //Collision型にはgameObjectやTransformなどの値が入っているから
        //↓のようにすればぶつかった相手の名前を取得出来る。
        Debug.Log(collision.gameObject.name);
    }

    /// <summary>
    /// （isTriggerチェック時）触れている間、呼ばれる
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("今Playerに触れているのは :" + other.gameObject.name);
    }


}
