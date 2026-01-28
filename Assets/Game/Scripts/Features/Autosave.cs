using UnityEngine;

namespace Game.Features
{
    public class Autosave : MonoBehaviour
    {
        private void OnApplicationPause(bool pause)
        {
            if (pause)
                GameData.Save();
        }
    }
}