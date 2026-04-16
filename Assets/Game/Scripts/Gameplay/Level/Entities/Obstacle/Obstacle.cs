using GameLoopManagement;
using UnityEngine;

namespace Game.Level.Entities
{
    public class Obstacle : MonoBehaviour
    {
        private GameObject[] _sections;

        public int SectionsCount => _sections.Length;

        private void Awake()
        {
            _sections = GetSections();

            GameLoop.Register(OnReset, FunctionType.Reset);
        }

        private GameObject[] GetSections()
        {
            var sections = new GameObject[transform.childCount];

            for (int i = 0; i < transform.childCount; i++)
                sections[i] = transform.GetChild(i).gameObject;

            return sections;
        }

        public void Build(ObstacleData data)
        {
            for (int i = 0; i < SectionsCount; i++)
            {
                var section = _sections[i];
                var enabled = data.SectionEnabled[i];

                section.SetActive(enabled);
            }
        }

        private void OnReset() => gameObject.SetActive(false);
    }
}