using System;

public class SingleObstacleCountStrategy : CountStrategy
{
    private readonly Obstacle _obstacle;

    private bool _canIncrement;

    public SingleObstacleCountStrategy(Character character, Obstacle obstacle) : base(character)
    {
        _obstacle       = obstacle;
        _canIncrement   = true;
    }

    public override void Update(Action addScore)
    {
        if (Character.transform.position.x <= _obstacle.transform.position.x)
            _canIncrement = true;

        if (_canIncrement && AddScoreConditionMet(_obstacle))
        {
            addScore.Invoke();

            _canIncrement = false;
        }
    }
}