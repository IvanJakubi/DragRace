using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentGoldText, currentRGoldText;
    [SerializeField] private TextMeshProUGUI rewardGoldText;
    [SerializeField] private TextMeshProUGUI skinPointsText;

    [Header("")]
    [SerializeField] private ScriptableEvent onUpdateGold;

    [Header("")]
    [SerializeField] private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        onUpdateGold.RaiseEvent(new EventMessage());
    }

    public void UpdateCurrentGold(EventMessage eventMessage)
    {
        currentGoldText.SetText(gameManager.goldCoins.ToString());
        currentRGoldText.SetText(gameManager.goldCoins.ToString());
    }

    public void UpdateRewardGoldAmount(EventMessage eventMessage)
    {
        rewardGoldText.SetText("Reward: " + gameManager.levelList[gameManager.currentLevel].goldCoinRewardWin.ToString());
    }
}
