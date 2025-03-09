using System;

public class ScoreCounter
{
    private readonly ObjectPool<Obstacle> _obstacles;
    private readonly Character _character;

    private int _score;

    public Action<int> Elapsed { get; set; }

    public ScoreCounter(ObjectPool<Obstacle> obstacles, Character character)
    {
        _obstacles = obstacles;
        _character = character;
    }

    public void Reset()
    {
        _score = 0;
    }
}