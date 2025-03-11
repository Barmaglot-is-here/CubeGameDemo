using System;

public abstract class CountStrategy
{
    protected readonly Character Character;

    public CountStrategy(Character character) => Character = character;

    public abstract void Update(Action addScore);

    protected bool AddScoreConditionMet(Obstacle obstacle)
        => obstacle.transform.position.x <= Character.transform.position.x;
}