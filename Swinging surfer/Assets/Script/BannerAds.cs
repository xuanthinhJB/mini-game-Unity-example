using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class BannerAds : MonoBehaviour {
	private BannerView bannerView;
	private string mTestDevice = "";
	// Use this for initialization
	void Start () {
		this.RequestBanner ();
	}
	
	private void RequestBanner() {
		#if UNITY_ANDROID 
		string adUnitID = "ca-app-pub-8726689659332482/5476108374";
		#endif

		//AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("").Build();

		AdRequest request = new AdRequest.Builder().Build();
		bannerView = new BannerView (adUnitID, AdSize.SmartBanner, AdPosition.Top);

		bannerView.LoadAd (request);
		bannerView.Show ();
	}
}
