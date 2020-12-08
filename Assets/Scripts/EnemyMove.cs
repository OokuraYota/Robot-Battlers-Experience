using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

/// <summary>
/// 目的地を指定するスクリプト
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour
{
    /*[SerializeField]
    private Player Player;
    */

    private NavMeshAgent _agent;

    //private RaycastHit[] _raycastHits = new RaycastHit[10];

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();//NavMeshAgentを保持しておく
    }

    /*private void Update()
    {
        //Playerを目指して進む
        _agent.destination = Player.transform.position;
    }*/

    //CollisionDetectorのonTriggerStayにセットし、衝突判定を受け取るメソッド
    public void OnDetectObject(Collider collider)
    {
        //検知したオブジェクトに『 Player 』のタグが付いていれば、そのオブジェクトを追いかける
        if (collider.CompareTag("Player"))
        {
            //時針とプレイヤーの座標差分を計算
            //var positionDiff = collider.transform.position - transform.position;

            //プレイヤーとの距離を計算
            //var distance = positionDiff.magnitude;

            //プレイヤーの方向
            //var direction = positionDiff.normalized;

            //raycastHitに、ヒットしたColliderや座標情報などが格納される
            //RaycastAllとRaycastAllocは同等の機能だが、RaycastNonAllocだとメモリにゴミが残らないのでこちらを推奨
            //var hitCount = Physics.RaycastNonAlloc(transform.position, direction, _raycastHits, distance);
            //Debug.Log("hitCount :" + hitCount);
            /*if (hitCount == 0)
            {
                //本作のプレイヤーは今のところColliderを使っていないのでRaycastはヒットしない
                //つまり、ヒット数が0であればプレイヤーとの間に障害物がないということになる
                _agent.isStopped = false;

                //AI.NavMeshAgent - destination - 
                //要求された目的地に最も近い有効な NavMesh の位置にエージェントを移動させることを要求します。
                _agent.destination = collider.transform.position;
            }
            else
            {
                //見失ったら停止する
                _agent.isStopped = true;
            }*/

            //AI.NavMeshAgent - destination - 
            //要求された目的地に最も近い有効な NavMesh の位置にエージェントを移動させることを要求します。
            _agent.destination = collider.transform.position;
        }
    }
}
