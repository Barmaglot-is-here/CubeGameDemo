using System.Collections.Generic;
using UnityEngine;

public class ObstacleSkin : BaseSkinView
{
    private SpriteRenderer[] _obstacleRenderers;
    private SpriteRenderer[] _shadowRenderers;

    public override string Tag => "Obstacle";

    private void Awake()
    {
        var obstacleRenderers   = new Queue<SpriteRenderer>();
        var shadowRenderers     = new Queue<SpriteRenderer>();

        int i = 0;
        foreach (Transform child in transform)
        {
            var sprite = child.GetComponent<SpriteRenderer>();
            var shadow = child.GetChild(0).GetComponent<SpriteRenderer>();

            obstacleRenderers.Enqueue(sprite);
            shadowRenderers.Enqueue(shadow);

            i++;
        }

        _obstacleRenderers  = obstacleRenderers.ToArray();
        _shadowRenderers    = shadowRenderers.ToArray();
    }

    public override void SetView(ViewData data)
    {
        foreach (var renderer in _obstacleRenderers)
            renderer.sprite = data.MainSprite;

        foreach (var renderer in _shadowRenderers)
            renderer.sprite = data.ShadowSprite;
    }
}