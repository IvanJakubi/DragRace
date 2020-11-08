using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    private string playstoreID = "3894513";
    private string appstoreID = "3894512";

    private string interstetialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";

    public bool isTargetPlaystore;
    public bool isTestAd;
    public RewardVideoType rewardVideoType;

    [Header("Scriptable Events")]
    public ScriptableEvent multiplierRewardEvent;
    public ScriptableEvent skinPointsRewardEvent;

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.AddListener(this);
        InitializeAdvertisement();
    }

    private void InitializeAdvertisement()
    {
        if (isTargetPlaystore)
        {
            Advertisement.Initialize(playstoreID, isTestAd);
            return;
        }
        Advertisement.Initialize(appstoreID, isTestAd);
    }

    public void PlayInterstetialAd()
    {
        if(!Advertisement.IsReady(interstetialAd))
        {
            return;
        }
        Advertisement.Show(interstetialAd);
    }

    public void PlayRewardedVideoAd()
    {
        if(!Advertisement.IsReady(rewardedVideoAd))
        {
            return;
        }
        Advertisement.Show(rewardedVideoAd);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch(showResult)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                if(placementId == rewardedVideoAd)
                {
                    switch (rewardVideoType)
                    {
                        case RewardVideoType.GoldMultiplier:
                            multiplierRewardEvent.RaiseEvent(new EventMessage());
                            break;
                        case RewardVideoType.SpecialSkinPoint:
                            skinPointsRewardEvent.RaiseEvent(new EventMessage());
                            break;
                    }

                }
                break;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //Mute game audio here
    }

    public void OnUnityAdsReady(string placementId)
    {
    }

    public void OnUnityAdsDidError(string message)
    {
    }
}
