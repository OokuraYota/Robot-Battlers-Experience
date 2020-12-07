using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCombo : StateMachineBehaviour
{
    //Unity連続攻撃、コンボ攻撃アニメーションを実現する方法

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Attack", false);
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
        animator.SetBool("Attack", false);
    }
}
