using System;
using System.Collections.Generic;

public class ScoreCounter
{
    private readonly IReadOnlyList<Obstacle> _obstacles;
    private readonly Character _character;

    private int _score;

    private Type _strategyType;
    private CountStrategy _strategy;

    public Action<int> OnCount { get; set; }

    public ScoreCounter(IReadOnlyList<Obstacle> obstacles, Character character)
    {
        _obstacles  = obstacles;
        _character  = character;

        SetStrategy<SingleObstacleCountStrategy>();
    }

    private void SetStrategy<T>() where T : CountStrategy
    {
        _strategyType = typeof(T);

        if (_strategyType == typeof(SingleObstacleCountStrategy))
            _strategy = new SingleObstacleCountStrategy(_character, _obstacles[0]);
        else if (_strategyType == typeof(MultiObstacleCountStrategy))
        {
            int currentObstacleIndex = _score != 0 ? 1 : 0;

            _strategy = new MultiObstacleCountStrategy(_character, _obstacles,
                                                       currentObstacleIndex);
        }
        else
            throw new NotImplementedException();
    }

    public void Update()
    {
        if (_obstacles.Count > 1 && _strategyType != typeof(MultiObstacleCountStrategy))
            SetStrategy<MultiObstacleCountStrategy>();

        _strategy.Update(IncrementScore);
    }

    private void IncrementScore()
    {
        _score++;

        OnCount?.Invoke(_score);
    }

    public void Reset() => _score = 0;
}