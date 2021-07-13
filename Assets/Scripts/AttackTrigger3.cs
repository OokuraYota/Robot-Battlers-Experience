using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger3 : StateMachineBehaviour
{
    public AudioClip audioClip3;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger("AttackTrigger");
        AudioSource.PlayClipAtPoint(audioClip3, animator.gameObject.transform.position);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}