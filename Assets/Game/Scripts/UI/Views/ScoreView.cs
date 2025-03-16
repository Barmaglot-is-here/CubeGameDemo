using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;

    public void Show(int score) => _scoreText.text = score.ToString();
}