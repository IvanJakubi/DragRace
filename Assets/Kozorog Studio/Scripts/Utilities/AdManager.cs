using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    private string playstoreID = "3894513";
    private string appstoreID = "3894512";

    private string interstetialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";
    private string bannerAd = "banner";

    public bool isTargetPlaystore;
    public bool isTestAd;
    public RewardVideoType rewardVideoType;

    [Header("Scriptable Events")]
    public ScriptableEvent skinPointsRewardEvent;
    public ScriptableEvent onAnimatedCoins;

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.AddListener(this);
        InitializeAdvertisement();
        StartCoroutine(ShowBannerAd());
    }

    private void InitializeAdvertisement()
    {
        if (!isTargetPlaystore)
        {
            Advertisement.Initialize(appstoreID, isTestAd);
            return;
        }

        Advertisement.Initialize(playstoreID, isTestAd);
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

    public IEnumerator ShowBannerAd()
    {
        if (!SaveData.current.hasNoAds && !SaveData.current.hasVIP)
        {
            while (!Advertisement.IsReady(bannerAd))
                yield return null;

            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(bannerAd);
        }

        yield return null;
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch(showResult)
        {
            case ShowResult.Failed:
                if (placementId == interstetialAd)
                    onAnimatedCoins.RaiseEvent(new EventMessage());
                break;
            case ShowResult.Skipped:
                if (placementId == interstetialAd)
                    onAnimatedCoins.RaiseEvent(new EventMessage());
                break;
            case ShowResult.Finished:
                if(placementId == rewardedVideoAd)
                {
                    switch (rewardVideoType)
                    {
                        case RewardVideoType.GoldMultiplier:
                            onAnimatedCoins.RaiseEvent(new EventMessage());
                            break;
                        case RewardVideoType.SpecialSkinPoint:
                            skinPointsRewardEvent.RaiseEvent(new EventMessage());
                            break;
                        case RewardVideoType.ShopGoldReward:
                            onAnimatedCoins.RaiseEvent(new EventMessage());
                            break;
                    }

                }
                if (placementId == interstetialAd)
                    onAnimatedCoins.RaiseEvent(new EventMessage());
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
