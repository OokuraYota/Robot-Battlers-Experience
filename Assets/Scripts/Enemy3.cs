﻿using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 目的地を指定するスクリプト
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy3 : MonoBehaviour //2021 02 09
{
    /*[SerializeField]
    private Player Player;*/

    private NavMeshAgent _agent;

    private Animator animator;

    /// <summary>
    /// 現在のライフ値
    /// </summary>
    public float life;

    /// <summary>
    /// ライフの最大値
    /// </summary>
    public float maxLife;

    //protected Enemy2Gauge enemy2Gauge;　//2021 02 09

    protected Enemy3Gauge enemy3Gauge;

    protected ShottingScript shotting;

    /// <summary>
    /// 死亡時に再生するエフェクト
    /// </summary>
    [SerializeField]
    GameObject effectDeadPrefab = null;

    //死亡爆破音
    public AudioClip audioClip;


    public GameObject BulletGun3;

    public void Start()
    {
        _agent = GetComponent<NavMeshAgent>();//NavMeshAgentを保持しておく
        animator = GetComponent<Animator>();//Animatorを保持しておく

        enemy3Gauge = GameObject.FindObjectOfType<Enemy3Gauge>(); //2021 02 09
        enemy3Gauge.SetEnemy3(this);  //2020 02 09
    }

    private void Update()
    {

    }

    public void OnDetectObjectExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            _agent.isStopped = true;
            animator.SetBool("Run", false);
        }
    }

    /// <summary>
    /// CollisionDetectorのonTriggerStayにセットし、衝突判定を受け取るメソッド
    /// </summary>
    /// <param name="collider"></param>
    public void OnDetectObject(Collider collider)
    {
        //検知したオブジェクトに『 Player 』のタグが付いていれば、そのオブジェクトを追いかける
        if (collider.CompareTag("Player"))
        {
            //要求された目的地に最も近い有効な NavMesh の位置にエージェントを移動させることを要求します。 AI.NavMeshAgent - destination - 
            _agent.isStopped = false;
            _agent.destination = collider.transform.position;
            animator.SetBool("Run", true);  //Runにする
        }
    }

    /// <summary>
    /// ダメージ処理
    /// </summary>
    /// <param name="power"></param>
    public void Damage(float power)
    {
        enemy3Gauge.GaugeReduction(power);  //2021 02 09
        Debug.Log(power);
        life -= power;

        //もし、現在のライフが０になったら死亡
        if (life <= 0)
        {
            //マイナス値になったら0にする
            life = 0;

            AudioSource.PlayClipAtPoint(audioClip, this.gameObject.transform.position);

            //死亡エフェクト再生
            GameObject instance = Instantiate(effectDeadPrefab);
            instance.transform.position = transform.position;

            Debug.Log("Playerが死亡判定されたため" + effectDeadPrefab + "を再生");

            //ゲームオブジェクトを非アクティブにして、非表示にする
            gameObject.SetActive(false);

            Destroy(BulletGun3);
        }
    }
}
