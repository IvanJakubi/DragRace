using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that acts as a holder for enums.
/// </summary>
public static class Enums
{
    public enum TriggerState
    {
        Triggered,
        Ready
    }

    public enum CarSkin
    {
        SWAT,
        Sherif,
        Soldier,
        FemaleCop
    }

    public enum GameState
    {
        Racing,
        Finish
    }

    public enum AudioClipType
    {
        Hit,
        Pickup,
        Gunshot,
        Rifleshot
    }
}
