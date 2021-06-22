using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCombo2 : StateMachineBehaviour
{
    public AudioClip audioClip2;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Attack", false);
        AudioSource.PlayClipAtPoint(audioClip2, animator.gameObject.transform.position);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //マウスの左クリックを押したら
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Attack", true);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Attack", false);
    }
}
