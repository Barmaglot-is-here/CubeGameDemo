using UnityEngine;

public abstract class DeathHandler
{
    public abstract string Tag { get; }

    public abstract void Handle(GameObject gameObject);
}