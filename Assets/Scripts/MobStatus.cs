using UnityEngine;

/// <summary>
/// Mob(動くオブジェクト、MovingObjectの略)の状態管理スクリプト
/// </summary>
public abstract class MobStatus : MonoBehaviour
{
    /// <summary>
    /// 状態の定義
    /// </summary>
    protected enum StateEnum
    {
        Nomal,  //通常
        Attack,  //攻撃中
        Die  //死亡
    }

    /// <summary>
    /// 移動可能かどうか
    /// </summary>
    public bool IsMovable => StateEnum.Nomal == _state;

    /// <summary>
    /// 攻撃可能かどうか
    /// </summary>
    public bool IsAttackable => StateEnum.Nomal == _state;

    /// <summary>
    /// ライフ最大値を返します
    /// </summary>
    public float LifeMax => lifeMax;

    /// <summary>
    /// 現在のライフ値（ヒットポイント）
    /// </summary>
    public float Life => _life;
    
    [SerializeField]
    private float lifeMax = 10;  //ライフの最大値

    protected Animator _animator;

    protected StateEnum _state = StateEnum.Nomal;  //Mob状態

    private float _life;  //現在のライフ値

    protected virtual void Start()
    {
        _life = lifeMax; //初期状態はライフ満タン
        _animator = GetComponentInChildren<Animator>();
    }

    //キャラクターが倒れた時の処理を記述します。
    protected virtual void OnDie()
    {

    }

    public void Damage(int damage)//現在はint型にしている
    {
        if (_state == StateEnum.Die) return;

        _life -= damage; //_life(現在のライフ値)にdamage値を引きます
        if (_life > 0) return; //もし現在のライフ値が０より大きければ戻ります。

        OnDie();
    }

    /// <summary>
    /// 可能であれば攻撃中の状態に遷移します
    /// </summary>
    public void GoToAttackStateIfPossible()
    {
        if (!IsAttackable) return; //もし攻撃可能ではないなら、戻ります。
        _state = StateEnum.Attack;
        _animator.SetTrigger("Attack");
    }

    /// <summary>
    /// 可能であればNormalの状態に遷移します。
    /// </summary>
    public void GoToNormalStateIfPossible()
    {
        if (_state == StateEnum.Die) return;  //もし死んでるなら戻ります。

        _state = StateEnum.Nomal;  //通常に戻ります。
    }
}
