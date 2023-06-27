using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AddsManager : MonoBehaviour, IUnityAdsShowListener, IUnityAdsInitializationListener, IUnityAdsLoadListener
{
    [SerializeField] string adToShow = "Rewarded_Android";


    private void Awake()
    {
        Advertisement.Initialize("5309676", true, this);
    }

    //public void ShowAdd()
    //{
    //    if(!Advertisement.isInitialized)
    //    {
    //        Debug.Log("no hay add");
    //        return;
    //    }

    //    Advertisement.Show(adToShow, this);
    //}
    
    
    //public void LoadInerAd()
    //{
    //    Advertisement.Load("Interstitial_Android", this);
    //}
    public void LoadRewardedAdd()
    {
        Advertisement.Load("Rewarded_Android", this);
    }
    
      
    public void OnUnityAdsShowClick(string placementId)
    {
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
    }

    public void OnUnityAdsShowStart(string placementId)
    {
    }

    public void OnInitializationComplete()
    {
        //LoadInerAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Advertisement.Show(placementId, this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }
}
