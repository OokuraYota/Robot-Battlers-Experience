using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGauge : MonoBehaviour
{
    [SerializeField]
    private Image GoldHP;
    [SerializeField]
    private Image purpleHP;

    private Player player;
    private Tween purpleHPTween;

    public void GaugeReduction(float reducationValue, float time = 1f)
    {
        var valueFrom = player.life / player.maxLife;
        var valueTo = (player.life - reducationValue) / player.maxLife;

        // 金ゲージ減少
        GoldHP.fillAmount = valueTo;

        if (purpleHPTween != null)
        {
            purpleHPTween.Kill();
        }

        // 紫ゲージ減少
        purpleHPTween = DOTween.To(
            () => valueFrom,
            x => {
                purpleHP.fillAmount = x;
            },
            valueTo,
            time
        );
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }
}