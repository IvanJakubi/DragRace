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
            SaveData.current.currentGold = goldCoins;
            SerializationManager.Save("playerData", SaveData.current);
        }
    }
    public int skinPoints;

    [Header("")]
    public bool hasNoAds;
    public bool hasVIP;

    [Header("")]
    public RewardData[] levelList;
    public List<CarType> unlockedCars;
    //public List<DriverType> unlockedDrivers;

    [Header("")]
    [SerializeField] private ScriptableEvent onUpdateGold;
    [SerializeField] private TextMeshProUGUI menuGoldText;
    [SerializeField] private TextMeshProUGUI rewardGoldText;
    [SerializeField] private TextMeshProUGUI shopGoldText;

    private int _c;

    private void Start()
    {
        SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/playerData.save");
        goldCoins = SaveData.current.currentGold;

        if (SaveData.current.unlockedCars == null)
            SaveData.current.unlockedCars = new List<CarType>();
        else
            unlockedCars = SaveData.current.unlockedCars;

        if (SaveData.current.unlockedDrivers == null)
            SaveData.current.unlockedDrivers = new List<DriverType>();
        //else
        //    unlockedDrivers = SaveData.current.unlockedSkins;
    }

    // Start is called before the first frame update
    public void GiveRewardMultiplier(EventMessage eventMessage)
    {
        goldCoins += levelList[currentLevel].goldCoinRewardWin * 5;
    }

    public void GiveRewardRegular (EventMessage eventMessage)
    {
        goldCoins += levelList[currentLevel].goldCoinRewardWin;
    }

    public void GiveShopGoldReward (EventMessage eventMessage)
    {
        goldCoins += 200;
    }
}
