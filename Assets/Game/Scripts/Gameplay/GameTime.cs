public static class GameTime
{
    private static float _savedValue;

    public static float BaseScale { get; set; }
    public static float Multiplier { get; set; }
    public static float Scale => BaseScale * Multiplier;

    static GameTime() => Reset();

    public static void Pause()
    {
        _savedValue = Multiplier;

        Multiplier = 0;
    }

    public static void Continue()
    {
        Multiplier = _savedValue;
    }

    public static void Reset()
    {
        Multiplier = BaseScale = _savedValue = 1;
    }
}