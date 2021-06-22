using DG.Tweening.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// SwordのBoxColliderとEnemyのBoxColliderの重なり判定
/// </summary>
public class SwordAttackCollider : MonoBehaviour
{
    public EnemyMove enemy;
    public EnemyBos enemyBos;
    public Enemy2 enemy2;
    public Enemy3 enemy3;
    public Enemy4 enemy4;

    void Start()
    {
        enemy = GetComponent<EnemyMove>();
        enemyBos = GetComponent<EnemyBos>();
        enemy2 = GetComponent<Enemy2>();
        enemy3 = GetComponent<Enemy3>();
        enemy4 = GetComponent<Enemy4>();
    }

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
        //Debug.Log("") → Swordが + EnemyのBox + Colliderに重なった!
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

        if (other.gameObject.GetComponent<EnemyMove>() == true)
        {
            Debug.Log("Enemy");
            other.gameObject.GetComponent<EnemyMove>().Damage(1.0f);

        }
        else if (other.gameObject.GetComponent<EnemyBos>() == true)
        {
            Debug.Log("EnmeyBos");
            other.gameObject.GetComponent<EnemyBos>().Damage(1.0f);
        }
        else if (other.gameObject.GetComponent<Enemy2>() == true)
        {
            Debug.Log("Enemy2");
            other.gameObject.GetComponent<Enemy2>().Damage(1.0f);
        }
        else if (other.gameObject.GetComponent<Enemy3>() == true)
        {
            Debug.Log("Enemy3");
            other.gameObject.GetComponent<Enemy3>().Damage(1.0f);
        }
        else if (other.gameObject.GetComponent<Enemy4>() == true)
        {
            Debug.Log("Enemy4");
            other.gameObject.GetComponent<Enemy4>().Damage(1.0f);
        }
    }
}