using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class ADManager : MonoBehaviour
{
    private RewardedAd rewardedAd;

    private string rewardedAd_ID;
    GameManager gameManager;
    private void Awake()
    {
        rewardedAd_ID = "ca-app-pub-3940256099942544/5224354917";
    }
    private void Start()
    {
        MobileAds.Initialize(initStatus => { });

        RequestRewardedVideo();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void RequestRewardedVideo()
    {
        rewardedAd = new RewardedAd(rewardedAd_ID);

        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardedAd.OnAdClosed += HandleRewardAdClosed;
        rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;

        AdRequest request = new AdRequest.Builder().Build();

        rewardedAd.LoadAd(request);
    }

    private void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs e)
    {
        RequestRewardedVideo();
    }

    private void HandleRewardAdClosed(object sender, EventArgs e)
    {
        
        RequestRewardedVideo();
        gameManager.adReward();

    }

    private void HandleUserEarnedReward(object sender, Reward e)
    {
        RequestRewardedVideo();
    }

    public void ShowRewardedVideo()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
    }
}
