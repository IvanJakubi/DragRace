using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CarData", menuName = "KozorogStudio/Cars/CarData", order = 1)]
public class CarsData : ScriptableObject
{
    public GameObject carPrefab;
    public CarRarity carRarity;
    public CarType carType;
}
