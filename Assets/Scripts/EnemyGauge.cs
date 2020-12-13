using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGauge : MonoBehaviour
{
    [SerializeField]
    private Image EnemyGoldHP;
    [SerializeField]
    private Image EnemybackHP;

    private EnemyMove enmey;
    private Tween EnemyBackTween;

    public void GaugeReduction(float reducationValue, float time = 1f)
    {
        var valueFrom = enmey.life / enmey.maxLife;
        var valueTo = (enmey.life - reducationValue) / enmey.maxLife;

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

    public void SetEnemy(EnemyMove enemy)
    {
        this.enmey = enemy;
    }
}