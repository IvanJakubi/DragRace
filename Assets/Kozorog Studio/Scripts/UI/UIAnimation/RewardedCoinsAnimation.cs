using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RewardedCoinsAnimation : MonoBehaviour
{
    [SerializeField] Image animatedCoinPrefab;
    [SerializeField] Transform target;

    [Space]
    [SerializeField] int maxCoins;
    Queue<Image> coinsQueue = new Queue<Image>();

    [Space]
    [SerializeField]
    [Range(0.5f, 0.9f)]
    float minAnimDuration;
    [SerializeField]
    [Range(0.9f, 2f)]
    float maxAnimDuration;

    [SerializeField] Ease easeType;
    [SerializeField] float spread;

    [SerializeField] ScriptableEvent onRewardMultiplierGiven;
    [SerializeField] ScriptableEvent onRegularRewardGiven;
    [SerializeField] ScriptableEvent onShopGoldReward;

    [SerializeField] AdManager adManager;

    Vector3 targetPosition;

    // Start is called before the first frame update
    void Awake()
    {
        targetPosition = target.position;

        PrepareCoins();
    }

    void PrepareCoins()
    {
        Image coin;
        for (int i = 0; i <maxCoins; i++)
        {
            coin = Instantiate(animatedCoinPrefab);
            coin.transform.SetParent(transform);
            coin.enabled = false;
            coinsQueue.Enqueue(coin);
        }

    }

    void AnimateCoins(int amount)
    {
        for(int i = 0; i<amount; i++)
        {
            if(coinsQueue.Count > 0)
            {
                Image coin = coinsQueue.Dequeue();
                coin.enabled = true;

                coin.transform.position = transform.position + new Vector3 (Random.Range(-spread, spread), Random.Range(-spread, spread), 0f);

                float duration = Random.Range(minAnimDuration, maxAnimDuration);
                coin.transform.DOMove(targetPosition, duration).SetEase(easeType).OnComplete(() =>
                 {
                     coin.enabled = false;
                     coinsQueue.Enqueue(coin);
                 });
            }
        }

        switch(adManager.rewardVideoType)
        {
            case RewardVideoType.InterstetialAd:
                onRegularRewardGiven.RaiseEvent(new EventMessage());
                break;

            case RewardVideoType.GoldMultiplier:
                onRewardMultiplierGiven.RaiseEvent(new EventMessage());
                break;

            case RewardVideoType.ShopGoldReward:
                onShopGoldReward.RaiseEvent(new EventMessage());
                break;
        }

    }

    public void OnAnimateCoins(EventMessage eventMessage)
    {
        AnimateCoins(maxCoins);
    }
}
