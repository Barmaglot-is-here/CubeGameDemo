using Game.SkinSystem;
using StateManagement;
using UnityEngine;

namespace Game.Features
{
    public class RandomSkinChange : MonoBehaviour, IResetable
    {
        [SerializeField]
        private SkinList _skinList;

        private void Awake() => StateManager.Register(this);
        private void Start() => SetRandomSkin();

        void IResetable.Reset() => SetRandomSkin();

        private void SetRandomSkin()
        {
            //SkinData skin = GetRandomSkin();

            //SkinChanger.Set(skin);
        }

        //private SkinData GetRandomSkin()
        //{
        //    int skisCount = _skinList.Skins.Length;

        //    int random = Random.Range(0, skisCount);

        //    return _skinList.Skins[random];
        //}
    }
}