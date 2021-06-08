using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2Gauge : MonoBehaviour
{
    /// <summary>
    /// 敵の前に表示されているHP画像
    /// </summary>
    [SerializeField]
    private Image EnemyGoldHP;

    /// <summary>
    /// 敵の後ろに表示されているHP画像
    /// </summary>
    [SerializeField]
    private Image EnemybackHP;

    //private EnemyMove enmey;


    /// <summary>
    /// ２体目の敵
    /// </summary>
    private Enemy2 enemy2;

    private Tween EnemyBackTween;


    public void GaugeReduction(float reducationValue, float time = 1f)
    {
        //var valueFrom = enmey2.life / enmey2.maxLife;
        var valueFrom = enemy2.life / enemy2.maxLife;
        //var valueTo = (enmey2.life - reducationValue) / enmey2.maxLife;
        var valueTo = (enemy2.life - reducationValue) / enemy2.maxLife;

        //前ゲージ減少
        EnemyGoldHP.fillAmount = valueTo;

        if (EnemyBackTween != null)
        {
            EnemyBackTween.Kill();
        }

        //後ろのゲージ減少
        EnemyBackTween = DOTween.To(
            () => valueFrom,
            x => {
                EnemybackHP.fillAmount = x;
            },
            valueTo,
            time
        );
    }

    public void SetEnemy2(Enemy2 enemy2)
    {
        //this.enmey2 = enemy2;
        this.enemy2 = enemy2;
    }
}
