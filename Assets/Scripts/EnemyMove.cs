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
            //AI.NavMeshAgent - destination - 
            //要求された目的地に最も近い有効な NavMesh の位置にエージェントを移動させることを要求します。
            _agent.destination = collider.transform.position;
        }
    }
}
