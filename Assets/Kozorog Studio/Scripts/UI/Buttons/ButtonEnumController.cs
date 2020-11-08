using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEnumController : MonoBehaviour
{
    public RewardVideoType rewardVideoType;
    public AdManager adManager;

    public void SetRewardType()
    {
        adManager.rewardVideoType = rewardVideoType;

        adManager.PlayRewardedVideoAd();
    }
}
