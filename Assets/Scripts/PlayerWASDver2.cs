using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWASDver2 : MonoBehaviour
{
    public float speed = 5f;
    public float rotateSpeed = 120f;

    /// <summary>
    /// アニメーター
    /// </summary>
    private Animator animator;  //2021 02 18

    /// <summary>
    /// 垂直方向の入力
    /// </summary>
    public float verticalInput = 0.0f;

    /// <summary>
    /// 水平方向の入力
    /// </summary>
    public float horizontalInput = 0.0f;


    public void Start()  //2021 02 18
    {
        //Animatorコンポーネントを取得
        animator = GetComponent<Animator>();
    }

    public void Update()//2021 02 18
    {
        //AnimationControllerのParametersに数値を送ってアニメーションを出す
        //animator.SetFloat("X", horizontalInput * 55);
        //animator.SetFloat("X", horizontalInput * 55);
        //animator.SetBool("XX", true);

        //animator.SetFloat("Y", verticalInput * 85);
        //animator.SetFloat("Y", verticalInput * 85);
        //animator.SetBool("YY", true);
    }

    void FixedUpdate()
    {
        //A・Dキー ⇔ 入力
        horizontalInput = Input.GetAxis("Horizontal");

        //W・Sキー ↕ 入力
        verticalInput = Input.GetAxis("Vertical");

        //GetAxisは1か-1を渡すからこのように記入した
        /*if (Input.GetAxis("Horizontal") == -1 || Input.GetAxis("Horizontal") == 1)
        {
            animator.SetBool("Run", true);
        }*/
        if (Input.GetAxis("Vertical") >= 0.1 || Input.GetAxis("Vertical") <= -0.1)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        Vector3 velocity = new Vector3(0, 0, verticalInput);

        // キャラクターのローカル空間での方向に変換
        velocity = transform.TransformDirection(velocity);

        // キャラクターの移動
        transform.localPosition += velocity * speed * Time.fixedDeltaTime;

        // キャラクターの回転
        transform.Rotate(0, horizontalInput * rotateSpeed * Time.fixedDeltaTime, 0);

    }
}