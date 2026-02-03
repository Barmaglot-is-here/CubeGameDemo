using UnityEngine;

namespace Game.Level
{
    public class DisableDeathHandler : DeathHandler
    {
        public override void Handle(GameObject gameObject) 
            => gameObject.SetActive(false);
    }
}