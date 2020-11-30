using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class DriverSpawnController : MonoBehaviour
{
    #region Public Variables
    public DriverType driverType;
    public SkinRarity driverRarity;

    [Header("")]
    public List<DriverList> driverRarityList;
    #endregion

    #region Private Variables
    private DriverList currentDriverRarity;
    private List<DriverData> currentDriverList;
    private DriverData driverToSpawn;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        SpawnDriver();
    }

    public void CallSpawnDriver(EventMessage eventMessage)
    {
        SpawnDriver();
    }

    public void CallDestroyDriver(EventMessage eventMessage)
    {
        DestroyDriver();
    }

    public void SpawnDriver()
    {
        for (int i = 0; i < driverRarityList.Count; i++)
        {
            if (driverRarityList[i].name == driverRarity.ToString())
            {
                currentDriverRarity = driverRarityList[i];
                break;
            }
        }

        currentDriverList = currentDriverRarity.driverList;

        for (int i = 0; i < currentDriverList.Count; i++)
        {
            if (currentDriverList[i].name == driverType.ToString())
            {
                driverToSpawn = currentDriverList[i];
                break;
            }
        }

        var newCarSpawn = Instantiate(driverToSpawn.driverPrefab, transform);
    }

    private void DestroyDriver()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
