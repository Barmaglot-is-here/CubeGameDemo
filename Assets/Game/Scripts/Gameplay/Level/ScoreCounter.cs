using System;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter
{
    private readonly Dictionary<Obstacle, GameObject> _counters;
    private readonly ObjectPool<Obstacle> _obstacles;
    private readonly GameObject _scoreTriggerPrefab;

    private int _score;

    private int Score 
    { 
        get => _score; 
        set
        {
            _score = value;

            OnScoreChanged?.Invoke(value);
        }
    }

    public Action<int> OnScoreChanged { get; set; }

    public ScoreCounter(ObjectPool<Obstacle> obstacles, GameObject scoreTriggerPrefab)
    {
        _counters           = new();
        _obstacles          = obstacles;
        _scoreTriggerPrefab = scoreTriggerPrefab;

        _obstacles.OnCreate += AddCounter;
        _obstacles.OnReset  += EnableCounter;
    }

    private void AddCounter(Obstacle obstacle)
    {
        var instance        = GameObject.Instantiate(_scoreTriggerPrefab,
                                                     obstacle.transform);

        var countComponent  = instance.GetComponent<ScoreCountComponent>();

        countComponent.OnCharacterPassed = IncrementScore;
        countComponent.OnCharacterPassed += () => DisableCounter(obstacle);

        _counters[obstacle] = instance;
    }

    private void IncrementScore() => Score++;

    private void EnableCounter(Obstacle obstacle) => _counters[obstacle].SetActive(true);
    private void DisableCounter(Obstacle obstacle) => _counters[obstacle].SetActive(false);

    public void Reset() => _score = 0;
}