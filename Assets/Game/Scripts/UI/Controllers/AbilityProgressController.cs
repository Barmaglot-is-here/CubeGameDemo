using Game.Abilities;
using UnityEngine;

namespace Game.UI
{
    public class AbilityProgressController : MonoBehaviour
    {
        [SerializeField]
        private ProgressView _progressView;

        private void OnEnable()
        {
            AbilitySystem.OnUse     += OnUse;
            AbilitySystem.OnUpdate  += _progressView.Show;
            AbilitySystem.OnExit    += HideView;
        }

        private void OnDisable()
        {
            AbilitySystem.OnUse     -= OnUse;
            AbilitySystem.OnUpdate  -= _progressView.Show;
            AbilitySystem.OnExit    -= HideView;
        }

        private void OnUse(IAbility ability)
        {
            ShowView();

            _progressView.SetMaximum(ability.Duration);
            _progressView.Show(0);
        }

        private void ShowView() => _progressView.gameObject.SetActive(true);
        private void HideView() => _progressView.gameObject.SetActive(false);
    }
}