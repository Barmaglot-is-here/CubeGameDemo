using UnityEngine;
using UIManagement;

public class ScoreTableScreen : BaseSubscreen
{
    [SerializeField]
    private ScoreTableView _scoreTableView;

    [ContextMenu("GenerateTable")]
    private void GenerateTable()
    {
        var records = FakeScoreTableGenerator.Generate(100);

        _scoreTableView.Fill(records);
    }
}