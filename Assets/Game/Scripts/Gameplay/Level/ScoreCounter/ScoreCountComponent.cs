using System;
using UnityEngine;

public class ScoreCountComponent : MonoBehaviour
{
    public Action OnCharacterPassed { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            OnCharacterPassed.Invoke();
    }
}