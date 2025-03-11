using UnityEngine;
using UnityEngine.UI;

public class PlayModeScoreView : MonoBehaviour
{
    [SerializeField]
    private GameObject _score;

    public void Show(int score)
    {
        Debug.Log(score);
    }
}