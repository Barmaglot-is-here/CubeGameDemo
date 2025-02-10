using UIManagement;
using UnityEngine;

public class UIRegistrator : MonoBehaviour
{
    [SerializeField]
    private BaseWindow[] _windows;

    [ContextMenu("UpdateWindowsList")]
    private void UpdateWindowsList()
    {
        _windows = FindObjectsByType<BaseWindow>(FindObjectsInactive.Include, 
                                                 FindObjectsSortMode.None);
    }

    private void Awake()
    {
        foreach (var window in _windows)
            UIManager.Register(window);

        _windows = null;
        Destroy(this);
    }
}
