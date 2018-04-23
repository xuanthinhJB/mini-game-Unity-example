using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdInitialize : MonoBehaviour {

	// Use this for initialization
	void Start () {
		#if UNITY_ANDROID
		string appID = "ca-app-pub-8726689659332482~1596573117";
		#endif

		MobileAds.Initialize(appID);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
