using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBosGauge : MonoBehaviour
{
    [SerializeField]
    private Image EnemyGoldHP;
    [SerializeField]
    private Image EnemybackHP;
    private EnemyBos enemyBos;
    private Tween EnemyBackTween;

    public void GaugeReduction(float reducationValue, float time = 1f)
    {
        var valueFrom = enemyBos.life / enemyBos.maxLife;
        var valueTo = (enemyBos.life - reducationValue) / enemyBos.maxLife;

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

    public void SetEnemy(EnemyBos enemyBos)
    {
        this.enemyBos = enemyBos;
    }
}
