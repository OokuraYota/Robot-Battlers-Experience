using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MobStatus))]
public class MobAttack : MonoBehaviour
{
    /// <summary>
    /// 攻撃後のクールダウン(秒)
    /// </summary>
    [SerializeField] private float attackCooldown = 0.5f;

    [SerializeField] private Collider attackCollider;

    private MobStatus _status;

    private void Start()
    {
        _status = GetComponent<MobStatus>();
    }

    /// <summary>
    /// 攻撃可能な状態であれば攻撃を行います
    /// </summary>
    public void AttackIfPossible()
    {
        //ステータスと衝突したオブジェクトで攻撃可否を判断
        if (!_status.IsAttackable) return;

        _status.GoToAttackStateIfPossible();
    }

    /// <summary>
    /// 攻撃対象が攻撃範囲に入ったときに呼ばれる
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
        attackCollider.enabled = true;
    }

    /// <summary>
    /// attackColliderが攻撃対象にHitしたときに呼ばれる
    /// </summary>
    /// <param name="collider"></param>
    public void OnHitAttack(Collider collider)
    {
        var targetMob = collider.GetComponent<MobStatus>();
        if (null == targetMob) return;

        //プレイヤーにダメージを与える
        targetMob.Damage(1);
    }

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
