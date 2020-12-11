using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /// <summary>
    /// 弾の速度
    /// </summary>
    [SerializeField]
    float speed = 10.0f;

    /// <summary>
    /// 弾の活動時間
    /// </summary>
    float activeTime = 0.0f;  //0.0秒から加算されて数えられるように

    /// <summary>
    /// 弾の生存時間
    /// </summary>
    [SerializeField]
    float lifeTime = 10.0f;  //10.0秒が生存時間の上限

    /*[SerializeField]  //先生が授業でおっしゃっていたカーブ（弾道のやつ）
    AnimationCurve moveYAnimCurve = null;
    */

    private void Update()
    {
        float time = activeTime / lifeTime;

        /*
         * Vector3.Lerp(始点となるベクトル位置, 終点となるベクトル位置,両端の距離を１とした時の割合)
         * Vector3 pos = Vector3.Lerp(startPos, endPos, time);
         */

        //活動時間は、時間でどんどん加算されていく
        activeTime += Time.deltaTime;
        //もし、弾の活動時間が生存時間を超えてしまったなら
        if (activeTime >= lifeTime)
        {
            //弾を完全に削除します。（Immediate = 即座）
            DestroyImmediate(gameObject);
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        //自分自身の攻撃・仲間なら無視する
        if (other.gameObject.layer == gameObject.layer)
        {
            return;
        }


    }
}
