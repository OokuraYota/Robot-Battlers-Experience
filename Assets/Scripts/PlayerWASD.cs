using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWASD : MonoBehaviour
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

    public void Start()
    {
        //Animatorコンポーネントを取得
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        GetInputs();

        //AnimationControllerのParametersに数値を送ってアニメーションを出す
        animator.SetFloat("X", horizontalInput * 55);
        animator.SetFloat("Y", verticalInput * 85);　　//Z

        //horizontalInputとverticalInputの数値に基づいて移動
        transform.position += transform.forward * verticalInput + transform.right * horizontalInput;
    }


    /// <summary>
    /// 入力を受け付ける
    /// </summary>
    public void GetInputs()
    {
        //W・Sキー ↕ 入力
        verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        //A・Dキー ⇔ 入力
        horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
    }
}
