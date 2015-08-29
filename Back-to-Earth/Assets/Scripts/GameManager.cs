using UnityEngine;
using System.Collections.Generic;

public static class GameManager
{
    public static List<PlatformControler> Platforms = new List<PlatformControler>();

    public static int Points;

    public static void AddPlatform(PlatformControler platform)
    {
        Platforms.Add(platform);
    }

    public static void RemovePlatform(PlatformControler platform)
    {
        Platforms.Remove(platform);
    }
}
