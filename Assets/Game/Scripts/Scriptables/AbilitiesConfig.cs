using UnityEngine;

[CreateAssetMenu(fileName = "AbilitiesConfig", menuName = "Configs/AbilitiesConfig")]
public class AbilitiesConfig : ScriptableObject
{
    [field: SerializeField]
    public SpeedFlyConfig SpeedFlyConfig { get; private set; }
}