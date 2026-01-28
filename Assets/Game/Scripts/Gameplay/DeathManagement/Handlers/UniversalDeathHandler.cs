using UnityEngine;

namespace Game
{
    public class UniversalDeathHandler : DeathHandler
    {
        public override void Handle(GameObject gameObject) => gameObject.SetActive(false);
    }
}