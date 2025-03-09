using System;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Action<GameObject> OnTrigger { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
        => OnTrigger.Invoke(collision.gameObject);
}