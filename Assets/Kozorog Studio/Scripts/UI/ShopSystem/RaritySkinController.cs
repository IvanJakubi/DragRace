using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class RaritySkinController : MonoBehaviour
{
    public int skinRarityIndex = 0;
    public SkinRarity skinRarity;
    public List<GameObject> showCarRarityIcons;
    public List<GameObject> showDriverRarityIcons;

    [SerializeField] GameObject leftArrow, rightArrow;
    [SerializeField] TextMeshProUGUI rarityText;

    private int skinRarityMax;

    private void Start()
    {
        skinRarityMax = System.Enum.GetValues(typeof(SkinRarity)).Length - 1;
    }

    // Start is called before the first frame update
    public void ChooseNextRarity()
    {
        if (skinRarityIndex < skinRarityMax)
        {
            skinRarityIndex++;
        }

        UpdateUI();
        
    }

    public void ChoosePreviousRarity()
    {
        if (skinRarityIndex > 0)
        {
            skinRarityIndex--;
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        skinRarity = (SkinRarity)skinRarityIndex;
        rarityText.text = skinRarity.ToString();

        foreach (GameObject obj in showCarRarityIcons)
            obj.SetActive(false);
        foreach (GameObject obj in showDriverRarityIcons)
            obj.SetActive(false);

        showCarRarityIcons[skinRarityIndex].SetActive(true);
        showDriverRarityIcons[skinRarityIndex].SetActive(true);

        if (skinRarityIndex == 0)
            leftArrow.SetActive(false);
        else
            leftArrow.SetActive(true);

        if (skinRarityIndex == skinRarityMax)
            rightArrow.SetActive(false);
        else
            rightArrow.SetActive(true);

    }
}
