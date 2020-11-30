using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkinButton : MonoBehaviour, IPointerClickHandler
{
    [Header("")]
    public SkinGroup skinGroup;
    public Image skinImage;
    public GameObject outline;
    
    [Header("")]
    public CarsData carData;
    public DriverData driverData;

    [Header("")]
    [SerializeField] ButtonInformationDistributer informationDistributer;
    [SerializeField] TabGroupEnum tabEnum;
    public CheckIfUnlocked unlockedSkin;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (unlockedSkin.isUnlocked.isUnlocked == 1)
        {
            if (tabEnum == TabGroupEnum.Cars)
                skinGroup.OnCarButtonSelected(this);
            else
                skinGroup.OnDriverButtonSelected(this);

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        skinGroup.Subscribe(this);
    }
}