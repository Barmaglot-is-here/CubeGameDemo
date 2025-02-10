using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;

    private IEnumerator _coroutine;

    public void Show(int score, bool startAnimation = true)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        if (startAnimation)
        {
            _coroutine = ScoreAnimation(score);

            StartCoroutine(_coroutine);
        }
        else
            _scoreText.text = score.ToString();
    }

    private IEnumerator ScoreAnimation(int score)
    {
        yield break;
    }
}