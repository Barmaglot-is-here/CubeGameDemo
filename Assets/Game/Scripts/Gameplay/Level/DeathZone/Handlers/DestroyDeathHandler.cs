using UnityEngine;

namespace Game.Level
{
    public class DestroyDeathHandler : DeathHandler
    {
        public override void Handle(GameObject gameObject)
            => GameObject.Destroy(gameObject);
    }
}