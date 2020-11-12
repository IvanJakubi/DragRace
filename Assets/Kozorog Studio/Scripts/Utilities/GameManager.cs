using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentLevel;
    
    [Header("")]
    public int goldCoins;
    public int skinPoints;

    [Header("")]
    public bool hasNoAds;
    public bool hasVIP;

    [Header("")]
    public RewardData[] levelList;

    [Header("")]
    [SerializeField] private ScriptableEvent onUpdateGold;

    // Start is called before the first frame update
    public void GiveRewardMultiplier(EventMessage eventMessage)
    {
        goldCoins += levelList[currentLevel].goldCoinRewardWin * 5;
        onUpdateGold.RaiseEvent(new EventMessage());
    }

    public void GiveRewardRegular (EventMessage eventMessage)
    {
        goldCoins += levelList[currentLevel].goldCoinRewardWin;
        onUpdateGold.RaiseEvent(new EventMessage());
    }
}
