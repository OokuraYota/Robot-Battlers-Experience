using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 目的地を指定するスクリプト
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBos : MonoBehaviour
{
    [SerializeField]
    public GameObject EnemyBosObject;
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

    protected EnemyBosGauge EnemyBosGauge;
    protected BosShottingScript shotting;

    /// <summary>
    /// 死亡時に再生するエフェクト
    /// </summary>
    [SerializeField]
    GameObject BosEffectDeadPrefab = null;

    //死亡爆破音
    public AudioClip audioClip;
    public PlayerWinNovelSceneScript playerWinNovelSceneScript;
    public EnemyBossAppears enemyBossAppears = null;
    public EnemyMove enemy;

    /// <summary>
    /// 1回だけ呼び出い処理
    /// </summary>
    bool isCalledOne = false;

    public void Start()
    {
        _agent = GetComponent<NavMeshAgent>();//NavMeshAgentを保持しておく
        animator = GetComponent<Animator>();//Animatorを保持しておく
        EnemyBosGauge = GameObject.FindObjectOfType<EnemyBosGauge>();
        EnemyBosGauge.SetEnemy(this);

        //最初は非アクティブにしておく
        this.gameObject.SetActive(false);
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

            //Runにする。
            animator.SetBool("Run", true);
        }
    }

    /// <summary>
    /// ダメージ処理
    /// </summary>
    /// <param name="power"></param>
    public void Damage(float power)
    {
        EnemyBosGauge.GaugeReduction(power);
        life -= power;

        //もし、現在のライフが０になったら死亡
        if (life <= 0)
        {
            //マイナス値になったら0にする
            life = 0;
            AudioSource.PlayClipAtPoint(audioClip, this.gameObject.transform.position);

            //死亡エフェクト再生
            GameObject instance = Instantiate(BosEffectDeadPrefab);
            instance.transform.position = transform.position;
            Debug.Log("Playerが死亡判定されたため" + BosEffectDeadPrefab + "を再生");

            //WinNovelSceneに遷移する処理を呼び出す
            playerWinNovelSceneScript.PlayerWinCoroutine();
            this.gameObject.SetActive(false);
        }
    }
}