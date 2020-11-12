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

        switch (rewardVideoType)
        {
            case RewardVideoType.InterstetialAd:
                adManager.PlayInterstetialAd();
                break;
            case RewardVideoType.GoldMultiplier:
                adManager.PlayRewardedVideoAd();
                break;
            case RewardVideoType.SpecialSkinPoint:
                adManager.PlayRewardedVideoAd();
                break;
        }
    }
}
