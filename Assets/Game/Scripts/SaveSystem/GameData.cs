using UnityEngine;

namespace Game
{
    public static class GameData
    {
        private static int _score;

        public static int Score
        {
            get => _score;
            set
            {
                if (value > _score)
                    _score = value;
            }
        }

        static GameData()
        {
            _score = PlayerPrefs.GetInt("score", 0);
        }

        public static void Save()
        {
            PlayerPrefs.SetInt("score", Score);

            PlayerPrefs.Save();
        }
    }
}
