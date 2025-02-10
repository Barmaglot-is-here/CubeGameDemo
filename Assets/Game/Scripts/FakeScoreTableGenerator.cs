using System;
using System.Collections.Generic;

public static class FakeScoreTableGenerator
{
    private const int MIN_SCORE = 1233;
    private const int MAX_SCORE = 25532;

    private static readonly string[] _firstNames =
    {
        "Barry",
        "Mr.",
        "Ice",
        "Victor",
        "Sandy",
        "Octocube",
        "Darth",
    };

    private static readonly string[] _lastNames =
    {
        "White",
        "Greendberg",
        "Cube",
        "Tosterson",
    };

    private static readonly Random _random;

    static FakeScoreTableGenerator()
    {
        _random = new();
    }

    public static ScoreTableRecordData[] Generate(int count)
    {
        ScoreTableRecordData[] datas    = new ScoreTableRecordData[count];
        var scores                      = GenerateScores(count);

        scores.Sort();
        scores.Reverse();

        for (int i = 0; i < count; i++)
        {
            ScoreTableRecordData data = new();

            data.UserName   = GenerateName();
            data.Position   = i + 1;
            data.Score      = scores[i];
            data.Date       = GenerateDate();

            datas[i] = data;
        }

        return datas;
    }
    
    private static List<int> GenerateScores(int count)
    {
        List<int> scores    = new(count);

        for (; count > 0; count--)
        {
            int score = _random.Next(MIN_SCORE, MAX_SCORE);

            scores.Add(score);
        }

        return scores;
    }

    private static string GenerateName()
    {
        int firstIndex  = _random.Next(0, _firstNames.Length);
        int lastIndex   = _random.Next(0, _lastNames.Length);
        string first    = _firstNames[firstIndex];
        string second   = _lastNames[lastIndex];

        return first + " " + second;
    }

    private static DateTime GenerateDate()
    {
        int year    = 2024;
        int mounth  = _random.Next(1, 12);
        int maxDays = DateTime.DaysInMonth(year, mounth);
        int day     = _random.Next(1, maxDays);

        return DateTime.Parse($"{day}/{mounth}/{year}");
    }
}