using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    private static SaveData _current;
    public static SaveData current
    {
        get
        {
            if (_current == null)
            {
                _current = new SaveData();
            }
            return _current;
        }
        set
        {
            if (value != null)
            {
                _current = value;
            }
        }
    }

    public int currentGold;
    public int currentLevel = 1;

    public bool hasVIP;
    public bool hasNoAds;

    public CarType currentCar;
    public DriverType currentDriver;

    public List<CarType> unlockedCars;
    public List<DriverType> unlockedDrivers;

}
