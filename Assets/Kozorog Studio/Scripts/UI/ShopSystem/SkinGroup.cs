using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinGroup : MonoBehaviour
{
    public List<SkinButton> skinButtons;
    public Color tabIdle;
    public Color tabActive;
    public SkinButton selectedSkin;

    [SerializeField] ScriptableEvent spawnCar;
    [SerializeField] ScriptableEvent destroyCar;
    [SerializeField] ScriptableEvent spawnDriver;
    [SerializeField] ScriptableEvent destroyDriver;
    [SerializeField] CarSpawnController carSpawnController;
    [SerializeField] DriverSpawnController driverSpawnController;

    public void Subscribe(SkinButton button)
    {
        if (skinButtons == null)
        {
            skinButtons = new List<SkinButton>();
        }

        skinButtons.Add(button);
    }

    public void OnCarButtonSelected(SkinButton button)
    {
        destroyCar.RaiseEvent(new EventMessage());
        selectedSkin = button;
        carSpawnController.carRarity = button.carData.carRarity;
        carSpawnController.carType = button.carData.carType;
        SaveData.current.currentCar = button.carData.carType;
        carSpawnController.SpawnCar();
        ResetButtons();
        button.outline.SetActive(true);
        SerializationManager.Save("playerData", SaveData.current);
    }

    public void OnDriverButtonSelected(SkinButton button)
    {
        destroyDriver.RaiseEvent(new EventMessage());
        selectedSkin = button;
        driverSpawnController.driverRarity = button.driverData.driverRarity;
        driverSpawnController.driverType = button.driverData.driverType;
        SaveData.current.currentDriver = button.driverData.driverType;
        driverSpawnController.SpawnDriver();
        ResetButtons();
        button.outline.SetActive(true);
        SerializationManager.Save("playerData", SaveData.current);
    }

    public void ResetButtons()
    {
        foreach (SkinButton button in skinButtons)
        {
            if (selectedSkin != null && button == selectedSkin) { continue; }
            button.outline.SetActive(false);
        }
    }
}
