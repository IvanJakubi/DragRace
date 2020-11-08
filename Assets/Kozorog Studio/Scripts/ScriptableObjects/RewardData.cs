using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelRewardData", menuName = "KozorogStudio/Rewards/LevelRewards")]
public class RewardData : ScriptableObject
{
    public int goldCoinRewardWin;
    public int goldCoinRewardLose;
    public int skinPointsReward;
}
