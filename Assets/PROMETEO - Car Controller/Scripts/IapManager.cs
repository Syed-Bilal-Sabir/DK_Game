using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IapManager : MonoBehaviour
{
    private string CoinsId= "com.serryplay.driftking.1000";
    private string AdRemoveId= "com.serryplay.driftking.noads";
    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id==CoinsId)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") +1000);
        }
        else if (product.definition.id==AdRemoveId)
        {
            PlayerPrefs.SetInt("RemoveAds", 1);
        }
    }

    
    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Your Purchase Failed because:"+ reason);
    }
}
