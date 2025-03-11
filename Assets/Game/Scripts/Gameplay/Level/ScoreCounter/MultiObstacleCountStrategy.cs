using System;
using System.Collections.Generic;

public class MultiObstacleCountStrategy : CountStrategy
{
    private readonly IReadOnlyList<Obstacle> _obstacles;

    private int _currentIndex;
    private Obstacle _current;

    public MultiObstacleCountStrategy(Character character, IReadOnlyList<Obstacle> obstacles, 
                                      int currentObstacleIndex) 
        : base(character)
    {
        _obstacles      = obstacles;
        _current        = obstacles[currentObstacleIndex];
        _currentIndex   = currentObstacleIndex;
    }

    public override void Update(Action addScore)
    {
        if (!_current.gameObject.activeSelf)
            return;

        if (AddScoreConditionMet(_current))
        {
            _current = Next();

            addScore.Invoke();
        }
    }

    private Obstacle Next()
    {
        _currentIndex = ++_currentIndex % _obstacles.Count;

        return _obstacles[_currentIndex];
    }
}