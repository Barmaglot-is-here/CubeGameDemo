using TMPro;
using UnityEngine;

public class GameSpeedDisplay : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    void Update()
    {
        _text.text = GameTime.Scale.ToString();
    }
}
