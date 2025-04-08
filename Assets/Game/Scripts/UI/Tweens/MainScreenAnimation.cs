using DG.Tweening;
using Unity.VectorGraphics;
using UnityEngine;

public class MainScreenAnimation : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _topButtons;
    [SerializeField]
    private GameObject _score;

    private RectTransform[] _transforms;
    private SVGImage[] _images;

    private RectTransform _scoreTransform;
    private SVGImage _scoreImage;

    private void Awake()
    {
        _transforms = new RectTransform[_topButtons.Length];
        _images     = new SVGImage[_topButtons.Length];

        for (int i = 0; i < _topButtons.Length; i++)
        {
            var button = _topButtons[i];

            _transforms[i]  = button.GetComponent<RectTransform>();
            _images[i]      = button.GetComponent<SVGImage>();
        }

        _scoreTransform = _score.GetComponent<RectTransform>();
        _scoreImage     = _score.GetComponent<SVGImage>();
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            OnEnable();
    }
#endif

    private void OnEnable()
    {
        for (int i = 0; i < _topButtons.Length; i++)
            PlayButtonAnimation(_transforms[i], _images[i]);

        PlayScoreAnimation();
    }

    private void PlayButtonAnimation(RectTransform transform, SVGImage image)
    {
        var targetPosition  = transform.localPosition;
        var targetColor     = image.color;

        var startPoint  = transform.sizeDelta.y;
        var endPoint    = transform.anchoredPosition.y;

        DOTween.Sequence()
            .Join
            (
                DOVirtual.Float(startPoint, endPoint, 0.2f, newPosition =>
                {
                    transform.anchoredPosition = new(transform.anchoredPosition.x, 
                                                     newPosition);
                })
            )
            .Join
            (
                DOVirtual.Float(0, 1, 0.2f, alpha =>
                {
                    image.color = new(targetColor.r, targetColor.g, targetColor.b, alpha);
                })
            );
    }

    private void PlayScoreAnimation()
    {
        var targetScale = _scoreTransform.localScale;
        var targetColor = _scoreImage.color;

        DOTween.Sequence()
            .Join
            (
                DOVirtual.Vector3(Vector3.zero, targetScale, 0.2f, scale =>
                {
                    _scoreTransform.localScale = scale;
                })
            )
            .Join
            (
                DOVirtual.Float(0, 1, 0.2f, alpha =>
                {
                    _scoreImage.color = new(targetColor.r, targetColor.g, targetColor.b, alpha);
                })
            );
    }
}