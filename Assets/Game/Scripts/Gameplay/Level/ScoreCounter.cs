using System;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter
{
    private readonly IReadOnlyList<Obstacle> _obstacles;
    private readonly GameObject _scoreTriggerPrefab;

    private int _prevObstaclesCount;
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

    public ScoreCounter(IReadOnlyList<Obstacle> obstacles, GameObject scoreTriggerPrefab)
    {
        _obstacles          = obstacles;
        _scoreTriggerPrefab = scoreTriggerPrefab;
    }

    public void Update()
    {
        if (_prevObstaclesCount < _obstacles.Count)
        {
            AddCounter(_obstacles[_prevObstaclesCount]);

            _prevObstaclesCount++;
        }
    }

    private void AddCounter(Obstacle obstacle)
    {
        var instance        = GameObject.Instantiate(_scoreTriggerPrefab,
                                                     obstacle.transform);

        var countComponent  = instance.GetComponent<ScoreCountComponent>();

        countComponent.OnCharacterPassed = IncrementScore;
    }

    private void IncrementScore() => Score++;

    public void Reset() => _score = 0;
}