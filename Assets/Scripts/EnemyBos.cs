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


        //enemyBossAppears.TheBossAppears();

        //EnemyBossAppears.TheBossAppears();
        //InvokeRepeating("Shot", 1, 1f);//1秒後に1秒ごとにShotを繰り出す
    }

    public void Update()
    {
        //enemyBossAppears.TheBossAppears();
        //EnemyBossAppears.TheBossAppears();
        //20210206
        //EnemyBossAppears.TheBossAppears();
        //EnemyBosActive();
        /*if (!isCalledOne)
        {
            isCalledOne = true;
            //Bosを表示させる
            EnemyBossAppears.TheBossAppears();
        }*/

        /*if (enemy.life <= 0)
        {
            this.gameObject.SetActive(true);
        }*/
    }

    public void OnDetectObjectExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            _agent.isStopped = true;
            animator.SetBool("Run", false);

            //Invokeを止める
            //CancelInvoke();
            //Debug.Log("Playerが範囲を出たので、Invokeを止める");
        }
    }

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

            //要求された目的地に最も近い有効な NavMesh の位置にエージェントを移動させることを要求します。 AI.NavMeshAgent - destination - 
            _agent.isStopped = false;
            _agent.destination = collider.transform.position;
            animator.SetBool("Run", true);  //Runにする



            ////InvokeRepeating("Shot", 1, 1f);//1秒後に1秒ごとにShotを繰り出す

            //Debug.Log("呼び出されているか？ :" + IsInvoking("Shot"));
            //InvokeRepeating("Shot", 1.0f, 1.0f);

            //1秒後に呼び出され、１秒毎に呼び出される
            //shotting.InvokeRepeating("Shot", 1, 1);
            //Invokeが呼び出されているか？
            //Debug.Log("呼び出されているか :" + IsInvoking("Shot"));
            //Invoke("Shot", 1); //1秒後に1秒ごとにShotを繰り出す
        }
        /*else  //もし範囲を出たなら
        {
            //Invokeを止める
            CancelInvoke();
            Debug.Log("Playerが範囲を出たので、Invokeを止める");
        }*/
    }

    /// <summary>
    /// ダメージ処理
    /// </summary>
    /// <param name="power"></param>
    public void Damage(float power)
    {
        EnemyBosGauge.GaugeReduction(power);
        life -= power;

        //もし、現在のライフが０になったら死亡　20200111
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

            //ゲームオブジェクトを非アクティブにして、非表示にする
            //this.gameObject.SetActive(false);
            /*if (life == 0)
            {
                this.gameObject.SetActive(false);
                //Destroy(this.gameObject);
            }*/

            //BosDestroy();
        }
    }

    /*public void BosDestroy()
    {
       
        Destroy(this.gameObject);
    }*/

    /// <summary>
    /// EnemyBosの表示
    /// </summary>
    /*public void EnemyBosActive()
    {
        //もし、普通の敵のlifeが0以下になったら
        if (enemy.life <= 0)
        {
            //Bosをアクティブにして登場
            this.gameObject.SetActive(true);
            //もしBosのlifeが0になったら
            if (life <= 0)
            {
                //Bosを非アクティブにする
                this.gameObject.SetActive(false);
            }
        }
    }*/

}


