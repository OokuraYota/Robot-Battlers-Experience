using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MobStatus))]
public class MobAttack : MonoBehaviour
{
    /// <summary>
    /// 攻撃後のクールダウン（秒）
    /// </summary>
    [SerializeField]
    private float attackCooldown = 0.5f;

    [SerializeField]
    private Collider attackCollider;

    private MobStatus _status;

    private void Start()
    {
        _status = GetComponent<MobStatus>();
    }

    public void AttackIfPossible()
    {
        if (!_status.IsAttackable) return;
        //ステータスと衝突したオブジェクトで攻撃可否を判断

        _status.GoToAttackStateIfPossible();
    }

    /// <summary>
    /// 攻撃対象が攻撃範囲内に入ったときに呼ばれる
    /// </summary>
    /// <param name="collider"></param>
    public void OnAttackRangeEnter(Collider collider)
    {
        AttackIfPossible();
    }

    /// <summary>
    /// 攻撃の開始時に呼ばれます
    /// </summary>
    public void OnAttackStart()
    {
        Debug.Log("攻撃が開始されたので呼ばれました");
        attackCollider.enabled = true;
    }

    /// <summary>
    /// attackColliderが攻撃対象にHitしたときに呼ばれます
    /// </summary>
    /// <param name="collider"></param>
    public void OnHitAttackCollider(Collider collider)
    {
        var targetMob = collider.GetComponent<MobStatus>();
        if (null == targetMob) return;

        //プレイヤーにダメージを与える
        Debug.Log("ダメージの値：" + targetMob);
        targetMob.Damage(1);
    }

    /// <summary>
    /// 攻撃の終了時に呼ばれます
    /// </summary>
    public void OnAttackFinished()
    {
        attackCollider.enabled = false;
        StartCoroutine(CooldownCoroutine());
    }

    private IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(attackCooldown);
        _status.GoToNormalStateIfPossible();
    }
}
