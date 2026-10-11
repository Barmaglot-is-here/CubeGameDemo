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

        public static int Coins { get; set; }

        static GameData()
        {
            _score  = PlayerPrefs.GetInt("score", 0);
            Coins   = PlayerPrefs.GetInt("coins", 0);
        }

        public static void Save()
        {
            PlayerPrefs.SetInt("score", Score);
            PlayerPrefs.SetInt("coins", Coins);

            PlayerPrefs.Save();
        }
    }
}
