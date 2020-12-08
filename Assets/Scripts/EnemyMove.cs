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
    [SerializeField]
    private Player Player;  //PlayerクラスのPlayerという変数

    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();//NavMeshAgentを保持しておく
    }
    private void Update()
    {
        //Playerを目指して進む
        _agent.destination = Player.transform.position;
    }
}
