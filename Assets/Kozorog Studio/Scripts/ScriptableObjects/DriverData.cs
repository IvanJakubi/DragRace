using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DriverData", menuName = "KozorogStudio/Drivers/DriverData")]
public class DriverData : ScriptableObject
{
    public GameObject driverPrefab;
    public SkinRarity driverRarity;
    public DriverType driverType;
    public Sprite unlockedDriver;
    public Sprite lockedDriver;
}
