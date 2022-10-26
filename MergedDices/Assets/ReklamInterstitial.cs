using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class ReklamInterstitial : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject rewardButton;

    private RewardedAd rewardedAd;
    [SerializeField]private string rewardedAd_ID;

    private void Start()
    {
        MobileAds.Initialize(initStatus => { });
        RequestRewardedVideo();
        rewardButton.SetActive(false);
    }

    private void Update()
    {
        if (playerController.dicesChangeCount == 0 && rewardedAd.IsLoaded())
        {
            rewardButton.SetActive(true);
        }
    }
    void RequestRewardedVideo()
    {        
        rewardedAd = new RewardedAd(rewardedAd_ID);
        rewardedAd.OnUserEarnedReward += HandlerUserEarnedReward;
        rewardedAd.OnAdClosed += HandlerRewardedAdClosed;
        rewardedAd.OnAdFailedToShow += HandlerRewardedFailedToShow;
        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request);
    }
    public void ShowRewardedVideo()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
    }
    private void HandlerUserEarnedReward(object sender, Reward e)
    {
        playerController.dicesChangeCount++;
        playerController.UpdateChangeText();
        RequestRewardedVideo();
        rewardButton.SetActive(false);
    }
    private void HandlerRewardedAdClosed(object sender, EventArgs e)
    {
        RequestRewardedVideo();
    }

    private void HandlerRewardedFailedToShow(object sender, AdErrorEventArgs e)
    {
        RequestRewardedVideo();
    }
}