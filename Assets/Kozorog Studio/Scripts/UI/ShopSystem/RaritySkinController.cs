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
    public List<GameObject> selectionCircle;

    [Header("")]
    [SerializeField] GameObject leftArrow, rightArrow;
    [SerializeField] TextMeshProUGUI rarityText;

    [Header("")]
    [SerializeField] GameObject buyWatch;
    [SerializeField] GameObject openBoxes;
    [SerializeField] GameObject vip;
    [SerializeField] UnlockSkinButton unlockSkinButton;

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
        foreach (GameObject obj in selectionCircle)
            obj.SetActive(false);

        showCarRarityIcons[skinRarityIndex].SetActive(true);
        showDriverRarityIcons[skinRarityIndex].SetActive(true);
        selectionCircle[skinRarityIndex].SetActive(true);

        if (skinRarityIndex == 0)
            leftArrow.SetActive(false);
        else
            leftArrow.SetActive(true);

        if (skinRarityIndex == skinRarityMax)
            rightArrow.SetActive(false);
        else
            rightArrow.SetActive(true);

        switch(skinRarityIndex)
        {
            case 0:
                buyWatch.SetActive(true);
                openBoxes.SetActive(false);
                vip.SetActive(false);
                unlockSkinButton.goldToSpend = 1000;
                unlockSkinButton.spendText.text = unlockSkinButton.goldToSpend.ToString();
                break;
            case 1:
                buyWatch.SetActive(true);
                openBoxes.SetActive(false);
                vip.SetActive(false);
                unlockSkinButton.goldToSpend = 2000;
                unlockSkinButton.spendText.text = unlockSkinButton.goldToSpend.ToString();
                break;
            case 2:
                buyWatch.SetActive(false);
                openBoxes.SetActive(true);
                vip.SetActive(false);
                break;
            case 3:
                buyWatch.SetActive(false);
                openBoxes.SetActive(false);
                vip.SetActive(true);
                break;
        }

    }
}
