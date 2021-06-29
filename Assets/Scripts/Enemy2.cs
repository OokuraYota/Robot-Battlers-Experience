using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 2体目の敵
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy2 : MonoBehaviour
{
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

    protected Enemy2Gauge enemy2Gauge;

    protected ShottingScript shotting;

    /// <summary>
    /// 弾丸のオブジェクト
    /// </summary>
    public GameObject Bullet;

    /// <summary>
    /// 死亡時に再生するエフェクト
    /// </summary>
    [SerializeField]
    GameObject effectDeadPrefab = null;

    //死亡爆破音
    public AudioClip audioClip;

    public void Start()
    {
        _agent = GetComponent<NavMeshAgent>();//NavMeshAgentを保持しておく
        animator = GetComponent<Animator>();//Animatorを保持しておく

        enemy2Gauge = GameObject.FindObjectOfType<Enemy2Gauge>();
        enemy2Gauge.SetEnemy2(this);
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
            //要求された目的地に最も近い有効な NavMesh の位置にエージェントを移動させることを要求します。
            //AI.NavMeshAgent - destination - 
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
        enemy2Gauge.GaugeReduction(power);
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

            Destroy(Bullet);
        }
    }
}