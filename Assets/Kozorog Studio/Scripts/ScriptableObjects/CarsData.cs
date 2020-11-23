using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CarData", menuName = "KozorogStudio/Cars/CarData", order = 1)]
public class CarsData : ScriptableObject
{
    public GameObject carPrefab;
    public SkinRarity carRarity;
    public CarType carType;
    public Image unlockedCar;
    public Image lockedCar;
}
