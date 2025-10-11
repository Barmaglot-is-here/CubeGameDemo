using System;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public Action OnTrigger { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
            OnTrigger.Invoke();
    }
}