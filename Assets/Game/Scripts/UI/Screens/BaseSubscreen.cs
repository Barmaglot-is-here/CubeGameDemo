using UIManagement;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSubscreen : BaseWindow
{
    [SerializeField] private Button _closeButton;

    protected virtual void Awake() => _closeButton.onClick.AddListener(OnCloseButtonClick);

    private void OnCloseButtonClick() => gameObject.SetActive(false);
}