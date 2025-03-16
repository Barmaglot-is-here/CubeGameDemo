using Cysharp.Threading.Tasks;
using StateManagement;
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
    private AddConfig _config;

    private float AddDuration => _config.Duration;

    private Stopwatch _timer;

    private void Awake()
    {
        _timer = new();

        _closeButton.onClick.AddListener(OnCloseButtonClick);
    }

    private void OnCloseButtonClick()
    {
        UIManager.Hide<AddScreen>();

        StateManager.SetState<PlayState>();
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

        while (_timer.Elapsed.Seconds < AddDuration)
        {
            _timerSlider.value = Convert(_timer.Elapsed, AddDuration);

            await UniTask.Yield();
        }

        _timer.Stop();
        _closeButton.gameObject.SetActive(true);
    }

    //Переименовать метод
    private float Convert(TimeSpan span, float target) 
        => (float)span.TotalMilliseconds / (target * 1000);
}