using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public sealed class FitBoxCollider2DToSprite : MonoBehaviour
{
    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();

        if (spriteRenderer.sprite == null)
        {
            Debug.LogWarning("Cannot fit BoxCollider2D: SpriteRenderer has no sprite.", this);
            return;
        }

        // Both the renderer bounds and the collider dimensions use local space.
        Bounds bounds = spriteRenderer.localBounds;
        boxCollider.size = new Vector2(bounds.size.x, bounds.size.y);
        boxCollider.offset = new Vector2(bounds.center.x, bounds.center.y);
    }
}
