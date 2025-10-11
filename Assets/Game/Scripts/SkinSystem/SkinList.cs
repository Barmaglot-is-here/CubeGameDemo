using System;
using UnityEngine;

[Serializable]
public struct Skin
{
    [field: SerializeField]
    public string Tag { get; private set; }
    [field: SerializeField]
    public ViewData View { get; private set; }
}

[Serializable]
public struct Tets
{
    [field: SerializeField]
    public Skin[] Skins { get; private set; }
}

[CreateAssetMenu(fileName = "SkinList", menuName = "Configs/SkinList")]
public class SkinList : ScriptableObject
{
    [field: SerializeField]
    public Tets[] Skins { get; private set; }
}
