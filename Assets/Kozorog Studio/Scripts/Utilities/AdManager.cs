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
    public ScriptableEvent multiplierRewardEvent;
    public ScriptableEvent skinPointsRewardEvent;

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
        while (!Advertisement.IsReady(bannerAd))
            yield return null;

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(bannerAd);
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
