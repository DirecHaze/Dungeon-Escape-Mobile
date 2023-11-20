using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsManager : MonoSingleton<AdsManager>, IUnityAdsLoadListener, IUnityAdsShowListener
{
    private string _androidAdId = "Rewarded_Android";

    public void LoadAd()
    {
        Advertisement.Load(_androidAdId, this);
    }
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ad Loaded: " + _androidAdId);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("Can't Load " + _androidAdId);
    }
    public void ShowAd()
    {
        Advertisement.Show(_androidAdId, this);
    }
    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        switch(showCompletionState)
        {
            case UnityAdsShowCompletionState.COMPLETED:
                GameManager.Program.AdsReward(200);
                Debug.Log("You got 200G");
                break;
            case UnityAdsShowCompletionState.SKIPPED:
                Debug.Log("You skip it no 200g");
                break;
                    
        }
      
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        throw new System.NotImplementedException();
    }
}