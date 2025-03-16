using UnityEngine;

[CreateAssetMenu(fileName = "AddConfig", menuName = "Configs/AddConfig")]
public class AddConfig : ScriptableObject
{
    [field: SerializeField]
    public float Duration { get; private set; }
}