using UnityEngine;

public class CharacterSkin : BaseSkinView
{
    private SpriteRenderer _characterRenderer;
    private SpriteRenderer _shadowRenderer;

    public override string Tag => "Player";

    private void Awake()
    {
        _characterRenderer  = GetComponent<SpriteRenderer>();
        _shadowRenderer     = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public override void SetView(ViewData data)
    {
        _characterRenderer.sprite   = data.MainSprite;
        _shadowRenderer.sprite      = data.ShadowSprite;
    }
}