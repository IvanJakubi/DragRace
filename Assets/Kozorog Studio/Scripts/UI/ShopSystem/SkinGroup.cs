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
    [SerializeField] CarSpawnController carSpawnController;

    public void Subscribe(SkinButton button)
    {
        if (skinButtons == null)
        {
            skinButtons = new List<SkinButton>();
        }

        skinButtons.Add(button);
    }

    public void OnButtonSelected(SkinButton button)
    {
        destroyCar.RaiseEvent(new EventMessage());
        selectedSkin = button;
        carSpawnController.carRarity = button.carData.carRarity;
        carSpawnController.carType = button.carData.carType;
        SaveData.current.currentCar = button.carData.carType;
        spawnCar.RaiseEvent(new EventMessage());
        ResetButtons();
        button.background.color = tabActive;
        SerializationManager.Save("playerData", SaveData.current);
    }

    public void ResetButtons()
    {
        foreach (SkinButton button in skinButtons)
        {
            if (selectedSkin != null && button == selectedSkin) { continue; }
            button.background.color = tabIdle;
        }
    }
}
