using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkinButton : MonoBehaviour, IPointerClickHandler
{
    [Header("")]
    public SkinGroup skinGroup;
    public Image background;
    public Image skinImage;
    public GameObject outline;
    
    [Header("")]
    public CarsData carData;
    public DriverData driverData;

    [Header("")]
    [SerializeField] ButtonInformationDistributer informationDistributer;
    [SerializeField] CheckIfUnlocked unlockedSkin;

    public void OnPointerClick(PointerEventData eventData)
    {
        skinGroup.OnButtonSelected(this);
        unlockedSkin.AddToList();
    }

    // Start is called before the first frame update
    void Start()
    {
        unlockedSkin = GetComponent<CheckIfUnlocked>();
        background = GetComponent<Image>();
        skinImage = GameObject.FindGameObjectWithTag("SkinImage").GetComponentInChildren<Image>();
        outline = GameObject.FindGameObjectWithTag("Outline");
        skinGroup.Subscribe(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
}