using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class CoinsView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _text;

        public void Show(int count) => _text.text = count.ToString();
    }
}
