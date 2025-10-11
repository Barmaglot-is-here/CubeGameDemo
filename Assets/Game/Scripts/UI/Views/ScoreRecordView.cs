using TMPro;
using UnityEngine;

public class ScoreRecordView : MonoBehaviour
{
    private const string DATE_FORMAT = "dd.MM.yyyy";

    [SerializeField]
    private TMP_Text _userNameText;
    [SerializeField]
    private TMP_Text _userPositionText;
    [SerializeField]
    private TMP_Text _scoreText;
    [SerializeField]
    private TMP_Text _dateText;

    public void Show(ScoreRecordData data)
    {
        _userNameText.text      = data.UserName;
        _userPositionText.text  = data.Position.ToString();
        _scoreText.text         = data.Score.ToString();
        _dateText.text          = data.Date.ToString(DATE_FORMAT);
    }
}