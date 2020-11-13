using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rewardGoldText;
    [SerializeField] private TextMeshProUGUI skinPointsText;

    [Header("")]
    [SerializeField] private GameManager gameManager;

    public void UpdateRewardGoldAmount(EventMessage eventMessage)
    {
        rewardGoldText.SetText("Reward: " + gameManager.levelList[gameManager.currentLevel].goldCoinRewardWin.ToString());
    }
}
