using Game.Tools;
using UnityEngine;

namespace Game.UI
{
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
}