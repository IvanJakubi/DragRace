using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfUnlocked : MonoBehaviour
{
    public UnlockedSkins isUnlocked;

    private SkinButton skinButton;

    // Start is called before the first frame update
    void Start()
    {
        skinButton = GetComponent<SkinButton>();

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

        //if(SaveData.current.unlockedSkins.Contains(this.GetComponent<GameObject>()))
        //{
        //    isUnlocked.isUnlocked = 1;
        //}
    }

    // Update is called once per frame
    public void AddToList()
    {
        if (isUnlocked.isUnlocked == 1)
            return;
        else
        {
            isUnlocked.isUnlocked = 1;
            SaveData.current.unlockedCars.Add(isUnlocked.carType);
        }

        SerializationManager.Save("playerData", SaveData.current);
    }
}
