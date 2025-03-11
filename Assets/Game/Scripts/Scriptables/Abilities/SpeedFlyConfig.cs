using UnityEngine;

[CreateAssetMenu(fileName = "SpeedFlyConfig", menuName = "Configs/Abilities/SpeedFlyConfig")]
public class SpeedFlyConfig : ScriptableObject
{
    [field: SerializeField]
    public float Duration { get; private set; }
}