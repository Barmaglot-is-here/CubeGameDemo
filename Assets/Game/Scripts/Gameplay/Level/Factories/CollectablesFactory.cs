using Game.Level.Entities;
using Game.Level.Generation;
using UnityEngine;

namespace Game.Level
{
    internal class CollectablesFactory : MonoBehaviour
    {
        [SerializeField]
        private Transform _container;
        [SerializeField]
        private GameObject _prefab;

        public Collectable Create(CollectableSpawnData data)
        {
            var collectable = Instantiate();

            collectable.transform.localPosition = data.Position;
            collectable.Setup(data.OnCollect, data.View);

            return collectable;
        }

        private Collectable Instantiate()
        {
            var instance        = Instantiate(_prefab, _container, true);
            var collectable     = instance.GetComponent<Collectable>();

            return collectable;
        }
    }
}
