using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int RevenuStatLevel { get; set; }
    public int CleanSpeedStatLevel { get; set; }
    public int Timelevel { get; set; }
    public int SpeedUpLevel { get; set; }
    public int CleanSpeedUpLevel { get; set; }
    public int RevenuUpLevel { get; set; }
    public int PassLevel { get; set; }
    public int MegaphoneLevel { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public int Hour { get; set; }
    public int Minute { get; set; }
    public int Second { get; set; }

    public PlayerData(PlayerStats playerStats)
    {
        RevenuStatLevel = playerStats.RevenuStatLevel;
        CleanSpeedStatLevel = playerStats.CleanSpeedStatLevel;
        Timelevel = playerStats.Timelevel;
        SpeedUpLevel = playerStats.SpeedUpLevel;
        CleanSpeedUpLevel = playerStats.CleanSpeedUpLevel;
        RevenuUpLevel = playerStats.RevenuUpLevel;
        PassLevel = playerStats.PassLevel;
        MegaphoneLevel = playerStats.MegaphoneLevel;
        Year = playerStats.Time.Year;
        Month = playerStats.Time.Month;
        Day = playerStats.Time.Day;
        Hour = playerStats.Time.Hour;
        Minute = playerStats.Time.Minute;
        Second = playerStats.Time.Second;
    }


}
