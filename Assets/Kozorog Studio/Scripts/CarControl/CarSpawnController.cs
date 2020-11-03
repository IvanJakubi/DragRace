using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CarSpawnController : MonoBehaviour
{
    public CarType carType;
    public CarRarity carRarity;

    [Header("")]
    public List<CarList> carRarityList;

    [Header("")]
    [SerializeField] private CarList currentCarRarity;
    [SerializeField] private List<CarsData> currentCarList;

    private CarsData carToSpawn;

    // Start is called before the first frame update
    void Start()
    {
                
    }

    public void SpawnCar(EventMessage eventMessage)
    {
        for (int i = 0; i < carRarityList.Count; i++)
        {
            if (carRarityList[i].name == carRarity.ToString())
            {
                currentCarRarity = carRarityList[i];
                break;
            }
        }

        currentCarList = currentCarRarity.carList;

        for (int i = 0; i < currentCarList.Count; i++)
        {
            if(currentCarList[i].name == carType.ToString())
            {
                carToSpawn = currentCarList[i];
                break;
            }
        }

        var newCarSpawn = Instantiate(carToSpawn.carPrefab, transform);
    }
}
