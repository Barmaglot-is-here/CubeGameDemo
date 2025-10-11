using System;
using System.Collections.Generic;

public static class SkinChanger
{
    private static Skin _currentSkin;

    private static readonly List<BaseSkinView> _views;

    static SkinChanger()
    {
        _views = new();
    }

    public static void Add(BaseSkinView view)
    {
        _views.Add(view);

        //obstacleSkin.Set(_currentSkin.ObstacleData);
    }

    public static void Set(Skin skin)
    {
        _currentSkin = skin;

        //_characterSkin.Set(skin.CharacterData);

        //foreach (var obstacleSkin in _obstacleSkins)
        //    obstacleSkin.Set(skin.ObstacleData);
    }
}