using Game.SkinSystem;
using GameLoopManagement;
using UnityEngine;

namespace Game.Features
{
    public class RandomSkinChange : MonoBehaviour
    {
        [SerializeField]
        private SkinList _skinList;

        private void Awake() => GameLoop.Register(OnReset, FunctionType.Reset);
        private void Start() => SetRandomSkin();

        private void OnReset() => SetRandomSkin();

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