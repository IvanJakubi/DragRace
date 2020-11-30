using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CarSpawnController : MonoBehaviour
{
    #region Public Variables
    public CarType carType;
    public SkinRarity carRarity;

    [Header("")]
    public List<CarList> carRarityList;
    #endregion

    #region Private Variables
    private CarList currentCarRarity;
    private List<CarsData> currentCarList;
    private CarsData carToSpawn;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        SpawnCar();
    }

    public void CallSpawnCar (EventMessage eventMessage)
    {
        SpawnCar();
    }

    public void CallDestroyCar (EventMessage eventMessage)
    {
        DestroyCar();
    }

    public void SpawnCar()
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

    private void DestroyCar()
    {
        foreach(Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
