using Cysharp.Threading.Tasks;
using System;
using System.Diagnostics;
using UIManagement;
using UnityEngine;
using UnityEngine.UI;

public class AddScreen : BaseWindow
{
    [SerializeField]
    private Slider _timerSlider;
    [SerializeField]
    private Button _closeButton;

    [SerializeField]
    private float _addDuration;

    private Stopwatch _timer;

    private void Awake()
    {
        _timer = new();

        _closeButton.onClick.AddListener(OnCloseButtonClick);
    }

    private void OnCloseButtonClick()
    {
        UIManager.Hide<AddScreen>();
        UIManager.Show<PlayModeScreen>();

        CharacterRebirth.Invoke();
    }

    private void OnEnable()
    {
        _closeButton.gameObject.SetActive(false);
        _timer.Reset();

        StartTimerTask().Forget();
    }

    private async UniTask StartTimerTask()
    {
        _timer.Start();

        while (_timer.Elapsed.Seconds < _addDuration)
        {
            _timerSlider.value = CalculateProgression(_timer.Elapsed, _addDuration);

            await UniTask.Yield();
        }

        _timer.Stop();
        _closeButton.gameObject.SetActive(true);
    }

    private float CalculateProgression(TimeSpan currentTime, float targetTime) 
        => (float)currentTime.TotalSeconds / targetTime;
}