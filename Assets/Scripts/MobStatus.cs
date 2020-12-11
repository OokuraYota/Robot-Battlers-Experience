using UnityEngine;

/// <summary>
/// 動くオブジェクトの状態管理スクリプト(MovingObjectの略)
/// </summary>
public abstract class MobStatus : MonoBehaviour //2020/12/11
{
    /// <summary>
    /// 状態の定義
    /// </summary>
    protected enum StateEnum
    {
        Normal, //通常
        Attack, //攻撃
        Die //死亡
    }

    /// <summary>
    /// 移動可能かどうか
    /// </summary>
    public bool IsMovable => StateEnum.Normal == _state;

    /// <summary>
    /// 攻撃可能かどうか
    /// </summary>
    public bool IsAttackable => StateEnum.Attack == _state;

    /// <summary>
    /// ライフの『最大値』を返す
    /// </summary>
    public float LifeMax => LifeMax;

    /// <summary>
    /// ライフの『値』を返す
    /// </summary>
    public float Life => _life;

    /// <summary>
    /// ライフの最大値
    /// </summary>
    [SerializeField] private float lifeMax = 10;

    protected Animator _animator;

    /// <summary>
    /// オブジェクトが動く状態
    /// </summary>
    protected StateEnum _state = StateEnum.Normal;

    /// <summary>
    /// 現在のライフ値（HP）
    /// </summary>
    private float _life;

    protected virtual void Start()
    {
        //初期状態はライフ満タン
        _life = lifeMax;
        _animator = GetComponentInChildren<Animator>();

        //ライフゲージの表示開始
        //LifeGaugeContainer.Instance.Add(this);

    }

    /// <summary>
    /// キャラクターが倒れた時の処理を記述
    /// </summary>
    protected virtual void OnDie()
    {
        //ライフゲージ表示終了
        //LifeGaugeContainer.Instance.Remove(this);
    }

    /// <summary>
    /// 指定数のダメージを受ける
    /// </summary>
    /// <param name="damage">指定数のダメージ</param>
    public void Damage(int damage)
    {
        if (_state == StateEnum.Die) return;//既に死んでいるときは処理を返しているのかな？

        Debug.Log("ライフが減りました");
        _life -= damage;
        if (_life > 0) return;//現在のライフ値がまだ０より値が大きいなら処理を返す

        _state = StateEnum.Die;
        _animator.SetTrigger("Die");//Dieのanimatorを起動

        OnDie();
    }

    /// <summary>
    /// 攻撃可能であれば攻撃中の状態に遷移
    /// </summary>
    public void GoToAttackStateIfPossible()
    {
        if (!IsAttackable) return;

        _state = StateEnum.Attack;
        _animator.SetTrigger("Attack");
    }

    /// <summary>
    /// 可能であればNormalの状態に遷移
    /// </summary>
    public void GoToNormalStateIfPossible()
    {
        if (_state == StateEnum.Die)return;
        _state = StateEnum.Normal;
    }
}
