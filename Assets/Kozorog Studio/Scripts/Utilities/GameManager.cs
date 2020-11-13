using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int currentLevel;
    
    //[Header("")]
    public int goldCoins {
        get { return _c; }
        set
        {
            _c = value;

            menuGoldText.text = goldCoins.ToString();
            rewardGoldText.text = goldCoins.ToString();
            shopGoldText.text = goldCoins.ToString();
        }
    }
    public int skinPoints;

    [Header("")]
    public bool hasNoAds;
    public bool hasVIP;

    [Header("")]
    public RewardData[] levelList;

    [Header("")]
    [SerializeField] private ScriptableEvent onUpdateGold;
    [SerializeField] private TextMeshProUGUI menuGoldText;
    [SerializeField] private TextMeshProUGUI rewardGoldText;
    [SerializeField] private TextMeshProUGUI shopGoldText;

    private int _c;

    private void Start()
    {
        menuGoldText.text = goldCoins.ToString();
        rewardGoldText.text = goldCoins.ToString();
        shopGoldText.text = goldCoins.ToString();
    }

    // Start is called before the first frame update
    public void GiveRewardMultiplier(EventMessage eventMessage)
    {
        goldCoins += levelList[currentLevel].goldCoinRewardWin * 5;
        //onUpdateGold.RaiseEvent(new EventMessage());
    }

    public void GiveRewardRegular (EventMessage eventMessage)
    {
        goldCoins += levelList[currentLevel].goldCoinRewardWin;
        //onUpdateGold.RaiseEvent(new EventMessage());
    }
}
