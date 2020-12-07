using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    /// プレイヤーのポジション
    /// </summary>
    //private Vector3 Player_pos;

    void Start()
    {
        //Animatorコンポーネントを取得
        animator = GetComponent<Animator>();
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

            Debug.Log("Locomotion");
            animator.SetBool("Attack", true);
        }

        //AnimationControllerのParametersに数値を送ってアニメーションを出す
        animator.SetFloat("X", horizontalInput * 50);
        animator.SetFloat("Y", verticalInput * 80);

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
}
