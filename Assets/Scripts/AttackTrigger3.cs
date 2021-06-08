using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger3 : StateMachineBehaviour
{
    public AudioClip audioClip3;
    //public AudioClip sound1;
    //public GameObject gameObject;
    //public AudioSource audioSource;
    //public AudioSord audioSord;

    //Unity連続攻撃、コンボ攻撃アニメーションを実現する方法

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //AudioSource.PlayClipAtPoint(audioClip, animator.gameObject.transform.position);

        //animator.SetBool("Attack", false);
        animator.SetTrigger("AttackTrigger");
        AudioSource.PlayClipAtPoint(audioClip3, animator.gameObject.transform.position);

        /*if (Input.GetMouseButtonDown(0))
        {
            AudioSource.PlayClipAtPoint(audioClip2, animator.gameObject.transform.position);
        }*/
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        //AudioSource.PlayClipAtPoint(audioClip, animator.gameObject.transform.position);
        /*if (Input.GetMouseButtonDown(0))//マウスの左クリックを押したら
        {
            animator.SetBool("Attack", true);
            //AudioSource.PlayClipAtPoint(audioClip2, animator.gameObject.transform.position);
        }*/
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.SetBool("Attack", false);

        //もし、左クリックを放したら
        /*if (Input.GetMouseButtonUp(0))
        {
            //Attackをfalseにする
            animator.SetBool("Attack", false);
        }*/
    }
}
