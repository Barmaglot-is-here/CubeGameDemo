using UnityEngine;

public class LevelSpeedController
{
    private readonly float _maxSpeed;
    private readonly float _speedGrow;

    public LevelSpeedController(float maxSpeed, float speedGrow)
    {
        _maxSpeed   = maxSpeed;
        _speedGrow  = speedGrow;
    }

    public void Update(int score)
    {
        if (GameTime.BaseScale >= _maxSpeed)
            return;

        GameTime.BaseScale = 1 + score * _speedGrow;
    }
}