using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [field: SerializeField]
    public float MoveForce { get; private set; }
    [field: SerializeField]
    public float Mass { get; private set; }
    [field: SerializeField]
    public float GravityScale { get; private set; }
}