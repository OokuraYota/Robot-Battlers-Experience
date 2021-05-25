using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//CapsuleColliderとRigidbodyを追加
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
/// <summary>
/// プレイヤー
/// </summary>
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

    protected PlayerGauge playerGauge;

    //ライフが半分になったら煙が出るエフェクト 2021/01/11
    [SerializeField]
    GameObject lifeHalf = null;

    float lifeHalfSetActive;

    // 死亡時に再生するエフェクト 2021/01/11
    [SerializeField]
    GameObject effectDeadPrefab = null;

    /// <summary>
    /// プレイヤーが死亡した時の管理
    /// </summary>
    public PlayerDieSceneManager playerDieSceneManager;


    //public AudioSource audioSource;
    public AudioClip audioClip;

    /// <summary>
    /// ロボットの足音
    /// </summary>
    //[SerializeField]
    //private AudioClip robotRunSound;

    /// <summary>
    /// プレイヤーのポジション
    /// </summary>
    //private Vector3 Player_pos;

    void Start()
    {
        //Animatorコンポーネントを取得
        animator = GetComponent<Animator>();

        //AudioSourceコンポーネントを取得
        // audioSource = GetComponent<AudioSource>();

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
        //W・Sキー　↕キーで前後移動
        //float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        //A・Dキー、⇔キーで横移動
        //float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

        //マウスを左クリックした瞬間にanimatorのAttackTrigerを呼ぶ
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("剣 攻撃１");
            //animator.SetTrigger("Attack Trigger");

            Debug.Log("剣攻撃");
            animator.SetBool("Attack", true);
        }

        //AnimationControllerのParametersに数値を送ってアニメーションを出す
        animator.SetFloat("X", horizontalInput * 55);
        animator.SetFloat("Y", verticalInput * 85);

        //horizontalInputとverticalInputの数値に基づいて移動
        transform.position += transform.forward * verticalInput + transform.right * horizontalInput;




        //PlayerのRigidbodyに対してInputにmoveSpeedをかけた値で更新し移動
        //rigid.velocity = new Vector3(horizontalInput * moveSpeed, 0, verticalInput * moveSpeed);

        //Playerがどの方向に進んでいるか分かるように、初期位置と現在地の座標差分を取得
        //Vector3 diff = transform.position - Player_pos;

        /*if (diff.magnitude > 0.01f)//ベクトルの長さが0.01fより大きい場合にPlayerの向きを変える処理を入れる
        {
            transform.rotation = Quaternion.LookRotation(diff);//ベクトルの情報をQuaternion.LOokRotationに引き渡し、回転量を取得しPlayerを回転させる
        }*/

        //Player_pos = transform.position;//プレイヤーの位置を更新
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();

        //カメラの方向から、x-z平面の単位ベクトルを取得
        //Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        //方向キーの入力値とカメラの向きから、移動方向を決定
        //Vector3 moveForward = cameraForward * verticalInput + Camera.main.transform.right * horizontalInput;
        //移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        //rigid.velocity = moveForward * moveSpeed + new Vector3(0, rigid.velocity.y, 0);
        //キャラクターの向きを進行方向に
        /*if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }*/


    }

    /// <summary>
    /// 入力を受け付ける
    /// </summary>
    private void GetInputs()
    {
        //W・Sキー ↕ 入力
        verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        //verticalInput = Input.GetAxis("Vertical");

        //A・Dキー ⇔ 入力
        horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        //horizontalInput = Input.GetAxis("Horizontal");

        //AWSDの入力を受け付けている間ってことは、PlayerRobotが走っている時なので
        //足音を鳴らします
        //AudioSource.PlayClipAtPoint(robotRunSound, this.gameObject.transform.position);
    }

    /// <summary>
    /// 前後に動く
    /// </summary>
    private void Move()
    {
        //rigid.velocity = transform.up * moveSpeed * verticalInput * Time.deltaTime;
    }


    /// <summary>
    /// 旋回する
    /// </summary>
    private void Rotate()
    {
        //rigid.MoveRotation(rigid.rotation + rotateSpeed * -horizontalInput * Time.deltaTime);
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
            //機体から故障の煙が出る Start()で非アクティブからアクティブにする
            //Debug.Log("HPが半分になったので、点灯します");

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



            //Playerが死亡した場合のSceneに飛ぶ
            //EndBattle();

            //EndBattleCoroutine();  
            //↑ここに書くと、ゲームオブジェクトが非アクティブになるため、コルーチンが開始できない
        }
    }

    /*public void EndBattleCoroutine()
    {
        //コルーチンを呼び出す
        StartCoroutine("EndBattle");
    }*/

    //コルーチン
    /*private IEnumerator EndBattle()
    {
        //3秒経過してから
        yield return new WaitForSeconds(3.0f);
        //Scene遷移
        SceneManager.LoadScene("PlayerDieScene");
    }*/

    /*void EndBattle()
    {
            Debug.Log("PlayerのHPが0になった為、ゲーム終了");
            SceneManager.LoadScene("PlayerDieScene");
    }*/
}
