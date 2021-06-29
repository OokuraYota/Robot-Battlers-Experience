using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCombo3 : StateMachineBehaviour
{
    /// <summary>
    /// ３コンボ目攻撃サウンド
    /// </summary>
    public AudioClip audioClip3;

    //Unity連続攻撃、コンボ攻撃アニメーションを実現する方法

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Attack", false);
        AudioSource.PlayClipAtPoint(audioClip3, animator.gameObject.transform.position);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetMouseButtonDown(0))//マウスの左クリックを押したら
        {
            animator.SetBool("Attack", true);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        //もし、左クリックを放したら
        if (Input.GetMouseButtonUp(0))
        {
            //Attackをfalseにする
            animator.SetBool("Attack", false);
        }
    }
}
