using UnityEngine;

[CreateAssetMenu(fileName = "ScoreCounterConfig", menuName = "Configs/ScoreCounterConfig")]
public class ScoreCounterConfig : ScriptableObject
{
    [field: SerializeField]
    public GameObject ScoreTriggerPrefab { get; private set; }
}