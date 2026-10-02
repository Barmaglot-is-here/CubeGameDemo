using Game.Utils;
using UnityEngine;

namespace Game.Assets.Game.Scripts.Gameplay.Utils
{
    internal class SpawnPositionInitializer : MonoBehaviour
    {
        enum ScreenBound
        {
            Left = -1,
            Right = 1,
        }

        [SerializeField]
        private ScreenBound _screenBound = ScreenBound.Right;

        [SerializeField]
        private float _offcetX;

        private void Awake()
        {
            var screenSize = ScreenSizeGetter.Get();

            var posX = screenSize.x / 2 * (int)_screenBound + _offcetX;

            transform.position = new(posX, transform.position.y, transform.position.z);

            Destroy(this);
        }
    }
}
