using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class AdMobHandler : MonoBehaviour
{
    public static AdMobHandler inst;
    //GameObject button;
    //int rate = 0;
    //public int showAdAfter = 8,
    //    RewardVaule = 100;
    //bool show;
    //////Ads
    //BannerView bannerAd;
    //InterstitialAd interAd;
    //RewardedAd rewardAd;
    //public string
    //    //Test Ads
    //    BannerId = "ca-app-pub-3940256099942544/6300978111",
    //    regularAd = "ca-app-pub-3940256099942544/1033173712",
    //    RewardId = "ca-app-pub-3940256099942544/5224354917";
    //private void Awake()
    //{
    //    inst = this;
    //    button = GameObject.FindGameObjectWithTag("Reward");
    //    LoadAll();
    //}
    public void LoadAll()
    {
        //if (bannerAd == null)
        //{
        //    RequestBanner();
        //}
        //else { bannerAd.Show(); }
        //if (rewardAd == null || rewardAd.IsLoaded() == false)
        //{
        //    RequestReward();
        //}
        //else
        //{
        //    ShowRewardButtons(null, null);
        //}
        //if (interAd == null || interAd.IsLoaded() == false)
        //{
        //    RequestInterstitial();
        //}
        //else
        //{
        //    rate++;
        //    ShowIntertical();
        //}
    }
    //IEnumerator Check()
    //{
    //    if (show)
    //    {
    //        Store.inst.SaveCoins(RewardVaule);
    //        show = false;
    //        StopCoroutine(Check());
    //    }
    //    yield return new WaitForSecondsRealtime(0.3f);
    //    StartCoroutine(Check());
    //}
    //Show
    public void ShowIntertical()
    {
        //if (rate >= showAdAfter)
        //{
        //    interAd.Show();
        //    rate = 0;
        //}
    }
    public void ShowReward()
    {
        //StartCoroutine(Check());
        //rewardAd.Show();
        //if (button != null)
        //{
        //    button.SetActive(false);
        //}
        //rewardAd.OnUserEarnedReward += EarnRewardStore;
    }
    ////UI
    //public void ShowRewardButtons(object sender, EventArgs args)
    //{
    //    if (rewardAd.IsLoaded() == true)
    //    {
    //        button.SetActive(true);
    //    }
    //    else
    //    {
    //        button.SetActive(false);
    //    }
    //}
    //void HandleOnAdLoaded(object sender, EventArgs args)
    //{
    //    bannerAd.Show();
    //}
    ////Reward
    //void EarnReward(object sender, Reward arg)
    //{
    //    show = true;
    //}
    //void EarnRewardStore(object sender, Reward arg)
    //{
    //    show = true;
    //}
    ////Request
    //private void RequestReward()
    //{
    //    rewardAd = new RewardedAd(RewardId);
    //    AdRequest request = new AdRequest.Builder().Build();
    //    rewardAd.LoadAd(request);
    //    rewardAd.OnAdLoaded += ShowRewardButtons;
    //}
    //private void RequestInterstitial()
    //{
    //    interAd = new InterstitialAd(regularAd);
    //    AdRequest request = new AdRequest.Builder().Build();
    //    interAd.LoadAd(request);
    //}
    //private void RequestBanner()
    //{
    //    bannerAd = new BannerView(BannerId, AdSize.Banner, AdPosition.Bottom);
    //    AdRequest request = new AdRequest.Builder().Build();
    //    bannerAd.LoadAd(request);
    //    bannerAd.OnAdLoaded += HandleOnAdLoaded;
    //}
}
