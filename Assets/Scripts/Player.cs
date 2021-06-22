using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//CapsuleColliderとRigidbodyを追加
/// <summary>
/// プレイヤーの管理
/// </summary>
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    /// <summary>
    /// アニメーター
    /// </summary>
    private Animator animator;

    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField]
    public float moveSpeed = 2.0f;

    /// <summary>
    /// 回転速度
    /// </summary>
    [SerializeField]
    float rotateSpeed = 1.0f;

    /// <summary>
    /// 垂直方向の入力
    /// </summary>
    float verticalInput = 0.0f;

    /// <summary>
    /// 水平方向の入力
    /// </summary>
    float horizontalInput = 0.0f;

    /// <summary>
    /// Rigidbodyコンポーネント
    /// </summary>
    Rigidbody rigid = null;

    /// <summary>
    /// 現在のライフ値
    /// </summary>
    public float life;

    /// <summary>
    /// ライフの最大値
    /// </summary>
    public float maxLife;

    /// <summary>
    /// プレイヤーのHPゲージ
    /// </summary>
    protected PlayerGauge playerGauge;

    /// <summary>
    /// ライフが半分になったら煙が出るエフェクト
    /// </summary>
    [SerializeField]
    GameObject lifeHalf = null;

    float lifeHalfSetActive;

    /// <summary>
    /// 死亡時に再生するエフェクト
    /// </summary>
    [SerializeField]
    GameObject effectDeadPrefab = null;

    /// <summary>
    /// プレイヤーが死亡した時の管理
    /// </summary>
    public PlayerDieSceneManager playerDieSceneManager;

    public AudioClip audioClip;

    void Start()
    {
        //Animatorコンポーネントを取得
        animator = GetComponent<Animator>();

        playerGauge = GameObject.FindObjectOfType<PlayerGauge>();
        playerGauge.SetPlayer(this); //2021 05 25 ここを消してしまうと、HPが減らなくなる

        //スクリプト側で参照をとってからアクティブの管理を行う
        //最初はアクティブになっているが、スクリプトで非アクティブにしている。
        lifeHalf = GameObject.Find("Malfunction");  //←オブジェクトの名前
        lifeHalf.SetActive(false);

        //lifeHalfSetActiveはmaxLifeの半分の値が入る
        lifeHalfSetActive = maxLife / 2;
        Debug.Log("lifeHalfSetActiveの値は :" + lifeHalfSetActive);
    }

    void Update()
    {
        GetInputs();

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("剣攻撃");
            animator.SetBool("Attack", true);
        }

        //AnimationControllerのParametersに数値を送ってアニメーションを出す
        animator.SetFloat("X", horizontalInput * 55);
        animator.SetFloat("Y", verticalInput * 85);

        //horizontalInputとverticalInputの数値に基づいて移動
        transform.position += transform.forward * verticalInput + transform.right * horizontalInput;
    }

    /// <summary>
    /// 入力を受け付ける
    /// </summary>
    private void GetInputs()
    {
        //W・Sキー ↕ 入力
        verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        //A・Dキー ⇔ 入力
        horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
    }

    /// <summary>
    /// ダメージ処理
    /// </summary>
    /// <param name="power"></param>
    public void Damage(float power)
    {
        playerGauge.GaugeReduction(power);
        life -= power;
        //Debug.Log("残りライフは" + life);

        //↓下記は文字＆数字どちらも色を付ける  2021 0511
        Debug.Log("<color=green>残りのライフは" +life+ "です。</color>");

        //↓下記は文字のみ色を付け、数字は普通のままにしている。
        //Debug.Log("<color=green>残りのライフは</color>" + life + "<color=green>です。</color>");


        //もし、ライフが半分(今は２)になったら
        if (life == lifeHalfSetActive)
        {
            lifeHalf.SetActive(true);
            Debug.Log("<color=yellow>HPが半分になったので、機体から故障の煙＆点灯します。</color>");
        }

        //もし、現在のライフが０になったら死亡　20200111
        if (life <= 0)
        {
            //PlayerDieSceneManagerのSceneTransitionを呼び出す
            playerDieSceneManager.SceneTransition();

            //マイナス値になったら0にする
            life = 0;

            AudioSource.PlayClipAtPoint(audioClip, this.gameObject.transform.position);

            //死亡エフェクト再生
            GameObject instance = Instantiate(effectDeadPrefab);
            instance.transform.position = transform.position;

            Debug.Log("Playerが死亡判定されたため" + effectDeadPrefab +"を再生");

            //ゲームオブジェクトを非アクティブにして、非表示にする
            gameObject.SetActive(false);  //全部非アクティブにする
        }
    }
}
