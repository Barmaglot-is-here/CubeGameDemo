using UnityEngine;

namespace Game.Utils
{
    public static class ScreenSizeGetter
    {
        public static Vector2 Get()
        {
            float height = Camera.main.orthographicSize * 2;

            return new(height * Camera.main.aspect, height);
        }
    }
}
