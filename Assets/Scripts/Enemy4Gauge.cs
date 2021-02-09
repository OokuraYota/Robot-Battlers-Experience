using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Enemy4Gauge : MonoBehaviour
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
    /// 3体目の敵
    /// </summary>
    private Enemy4 enemy4;

    private Tween EnemyBackTween;


    public void GaugeReduction(float reducationValue, float time = 1f)
    {
        //var valueFrom = enmey2.life / enmey2.maxLife;
        var valueFrom = enemy4.life / enemy4.maxLife;
        //var valueTo = (enmey2.life - reducationValue) / enmey2.maxLife;
        var valueTo = (enemy4.life - reducationValue) / enemy4.maxLife;

        // 前ゲージ減少
        EnemyGoldHP.fillAmount = valueTo;

        if (EnemyBackTween != null)
        {
            EnemyBackTween.Kill();
        }

        // 後ろのゲージ減少
        EnemyBackTween = DOTween.To(
            () => valueFrom,
            x => {
                EnemybackHP.fillAmount = x;
            },
            valueTo,
            time
        );
    }

    public void SetEnemy4(Enemy4 enemy4)
    {
        //this.enmey2 = enemy2;
        this.enemy4 = enemy4;
    }
}