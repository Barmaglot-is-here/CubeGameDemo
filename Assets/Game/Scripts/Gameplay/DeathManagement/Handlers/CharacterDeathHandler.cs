using Game.Level;
using Game.UI;
using StateManagement;
using UIManagement;
using UnityEngine;

namespace Game
{
    public class CharacterDeathHandler : DeathHandler
    {
        public override void Handle(GameObject gameObject)
        {
            var scoreCounter = Level.Level.Services.Get<ScoreCounter>();

            GameData.Score = scoreCounter.Score;
            GameData.Save();

            StateManager.SetState<PauseState>();
            UIManager.Hide<PlayModeScreen>();
            UIManager.Show<DeathScreen>();
        }
    }
}