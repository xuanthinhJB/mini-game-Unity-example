using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class RewardedVideo : MonoBehaviour {
	private BannerView bannerView;
	private RewardBasedVideoAd rewardBasedVideoAds;
	//public Button btnWatchVideo;
	public GameObject dialogNetworkError;
	//public Button btnOK;
	private Animator dialogAnimator;
	private AudioSource audioSource;
	private int sound;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		sound = PlayerPrefs.GetInt ("sound", 1);
		checkSoundPlay (sound);

		dialogAnimator = dialogNetworkError.GetComponent<Animator> ();

		this.rewardBasedVideoAds = RewardBasedVideoAd.Instance;
		this.RequestRewardedVideo ();
		// Called when an ad request has successfully loaded.
		rewardBasedVideoAds.OnAdLoaded += HandleRewardBasedVideoLoaded;
		// Called when an ad request failed to load.
		rewardBasedVideoAds.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
		// Called when an ad is shown.
		rewardBasedVideoAds.OnAdOpening += HandleRewardBasedVideoOpened;
		// Called when the ad starts to play.
		rewardBasedVideoAds.OnAdStarted += HandleRewardBasedVideoStarted;
		// Called when the user should be rewarded for watching a video.
		rewardBasedVideoAds.OnAdRewarded += HandleRewardBasedVideoRewarded;
		// Called when the ad is closed.
		rewardBasedVideoAds.OnAdClosed += HandleRewardBasedVideoClosed;
		// Called when the ad click caused the user to leave the application.
		rewardBasedVideoAds.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

		/*
		Button button1 = btnWatchVideo.GetComponent<Button> ();
		button1.onClick.AddListener (showVideoAd);	

		Button button2 = btnOK.GetComponent<Button> ();
		button2.onClick.AddListener (closeDialogNetWork);
		*/

	}

	public void checkSoundPlay(int sound){
		if (sound == 1) {
			audioSource.mute = false;
		} else if (sound == 0) {
			audioSource.mute = true;
		}
	}


	
	private void RequestRewardedVideo(){
		#if UNITY_ANDROID
		string adUnitIDReward = "ca-app-pub-8726689659332482/7471732230";
		string adUnitIDbanner = "ca-app-pub-8726689659332482/8918236348";
		#endif

		AdRequest request1 = new AdRequest.Builder ().Build ();
		//AdRequest request1 = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("").Build();
		this.rewardBasedVideoAds.LoadAd (request1, adUnitIDReward);

		AdRequest request2 = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("").Build();
		bannerView = new BannerView (adUnitIDbanner, AdSize.SmartBanner, AdPosition.Bottom);
		bannerView.LoadAd (request2);
	}

	public void showVideoAd() {
		if (rewardBasedVideoAds.IsLoaded()) {
			rewardBasedVideoAds.Show ();
		} else SceneManager.LoadSceneAsync ("PlayScene");
		//dialogAnimator.SetBool("IsDialogOpen", true);
		/*
		if (Application.internetReachability == NetworkReachability.NotReachable) {
			// show dialog
			dialogAnimator.SetBool("IsDialogOpen", true);
			Debug.Log("Network not available");

		}
		if (rewardBasedVideoAds.IsLoaded()) {
			dialogAnimator.SetBool("IsDialogOpen", true);
			//rewardBasedVideoAds.Show ();
		} else {
			// show warning network not available
			Debug.Log("Network not available");
			dialogAnimator.SetBool("IsDialogOpen", true);
		}*/
	}

	public void closeDialogNetWork() {
		dialogAnimator.SetBool ("IsDialogOpen", false);
	}

	public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
		//rewardBasedVideoAds.Show ();
		Debug.Log ("Load ad success");

	}

	public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		MonoBehaviour.print(
			"HandleRewardBasedVideoFailedToLoad event received with message: "
			+ args.Message);
	}

	public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
	}

	public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
	}

	public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
		//PlayerPrefs.SetInt ("WatchVideoAd", 1);
		SceneManager.LoadSceneAsync ("PlayScene");
	}

	public void HandleRewardBasedVideoRewarded(object sender, Reward args)
	{
		string type = args.Type;
		double amount = args.Amount;
		MonoBehaviour.print(
			"HandleRewardBasedVideoRewarded event received for "
			+ amount.ToString() + " " + type);
	}

	public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
	}


}
