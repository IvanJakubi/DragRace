using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInformationDistributer : MonoBehaviour
{
    public CarList carList;
    public DriverList driverList;
    public bool isCarList;

    [SerializeField] List<SkinButton> buttonHolders; 

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            buttonHolders.Add(transform.GetChild(i).GetComponent<SkinButton>());
        }

        if (isCarList == true)
            SetCarData();
        else
            SetDriverData();   
    }

    private void SetCarData()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            buttonHolders[i].carData = carList.carList[i];
            buttonHolders[i].unlockedSkin.PrepareCarButton();
        }
    }

    private void SetDriverData()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            buttonHolders[i].driverData = driverList.driverList[i];
            buttonHolders[i].unlockedSkin.PrepareDriverButton();
        }
    }
}
