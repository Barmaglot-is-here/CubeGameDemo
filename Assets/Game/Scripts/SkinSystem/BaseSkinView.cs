using UnityEngine;

public abstract class BaseSkinView : MonoBehaviour
{
    public abstract string Tag { get; }

    private void Awake()
    {
        SkinChanger.Add(this);
    }

    public abstract void SetView(ViewData data);
}