using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfUnlocked : MonoBehaviour
{
    public UnlockedSkins isUnlocked;

    public SkinButton skinButton;

    // Start is called before the first frame update
    public void PrepareCarButton()
    {
        //skinButton = GetComponent<SkinButton>();
        isUnlocked.carType = skinButton.carData.carType;

        if (SaveData.current.unlockedCars.Count == 0)
        {
            if (isUnlocked.isUnlocked == 1)
            {
                SaveData.current.unlockedCars.Add(isUnlocked.carType);
            }
        }

        if (SaveData.current.unlockedCars.Contains(isUnlocked.carType))
        {
            isUnlocked.isUnlocked = 1;
        }

        UnlockLockCarImage();
    }

    public void PrepareDriverButton()
    {
        isUnlocked.driverType = skinButton.driverData.driverType;

        if (SaveData.current.unlockedDrivers.Count == 0)
        {
            if (isUnlocked.isUnlocked == 1)
            {
                SaveData.current.unlockedDrivers.Add(isUnlocked.driverType);
            }
        }

        if (SaveData.current.unlockedDrivers.Contains(isUnlocked.driverType))
        {
            isUnlocked.isUnlocked = 1;
        }

        UnlockLockDriverImage();
    }

    // Update is called once per frame
    public void AddCarToList()
    {
        SaveData.current.unlockedCars.Add(isUnlocked.carType);
        
        SerializationManager.Save("playerData", SaveData.current);
    }

    public void AddDriverToList()
    {
        SaveData.current.unlockedDrivers.Add(isUnlocked.driverType);

        SerializationManager.Save("playerData", SaveData.current);
    }

    public void UnlockLockCarImage()
    {
        if (isUnlocked.isUnlocked == 1)
        {
            //Set unlocked image here
            skinButton.skinImage.sprite = skinButton.carData.unlockedCar;
        }
        else
            //Set locked image here
            skinButton.skinImage.sprite = skinButton.carData.lockedCar;
    }

    public void UnlockLockDriverImage()
    {
        if (isUnlocked.isUnlocked == 1)
        {
            //Set unlocked image here
            skinButton.skinImage.sprite = skinButton.driverData.unlockedDriver;
        }
        else
            //Set locked image here
            skinButton.skinImage.sprite = skinButton.driverData.lockedDriver;
    }
}
