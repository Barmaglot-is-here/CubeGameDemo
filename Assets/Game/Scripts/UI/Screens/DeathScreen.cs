using DG.Tweening;
using UIManagement;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : BasePauseScreen
{
    [SerializeField] 
    private Button _watchAdButton;

    private Canvas _canvas;

    private int _defaultScoreViewOrder;

    protected override void Awake()
    {
        base.Awake();

        _watchAdButton.onClick.AddListener(OnWatchAdButtonClick);

        _canvas             = GetComponent<Canvas>();
    }

    private void OnEnable()
    {
        PlayShowAnimation(HomeButton.transform, 0.1f);
        PlayShowAnimation(_watchAdButton.transform, 0.2f);
        PlayShowAnimation(RestartButton.transform, 0.3f);

        ShowScoreView();
        PlayShowAnimation(ScoreView.transform, 0.5f);
    }

    private void PlayShowAnimation(Transform target, float delay)
    {
        var defaultScale    = target.localScale;
        target.localScale   = Vector3.zero;

        DOVirtual.Vector3(Vector3.zero, defaultScale, 0.2f, newScale =>
        {
            target.localScale = newScale;
        }).SetDelay(delay);
    }

    private void ShowScoreView()
    {
        _defaultScoreViewOrder = ScoreView.OrderInLayer;
        ScoreView.OrderInLayer = _canvas.sortingOrder + 1;
    }

    private void HideScoreView()
    {
        ScoreView.OrderInLayer = _defaultScoreViewOrder;
    }

    private void OnDisable() => HideScoreView();

    protected override void OnRestartButtonClick()
    {
        base.OnRestartButtonClick();

        UIManager.Hide<DeathScreen>();
    }

    protected override void OnHomeButtonClick()
    {
        base.OnHomeButtonClick();

        UIManager.Hide<DeathScreen>();
    }

    private void OnWatchAdButtonClick()
    {
        UIManager.Hide<DeathScreen>();
        UIManager.Show<AddScreen>();
    }
}