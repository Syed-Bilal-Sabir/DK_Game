using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HomeUi : MonoBehaviour
{
  
    public TMP_InputField inputField;
    public TMP_Text usernme;
    //public GameObject userNamePrompt;
    public GameObject CarGarage;
    public GameObject HomePanel;
    public GameObject shopPanel;

    public GameObject [] shopItems;
    int currentItem;
    bool HasOpened = false;
    public TMP_Text ProfileName;

    private void Start()
    {
        
        /*if (PlayerPrefs.GetString("Username") == "")
        {
            userNamePrompt.SetActive(true);
        }
        else
        {
            ProfileName.text = PlayerPrefs.GetString("Username");
        }*/

    }
   /* private void Update()
    {
        
        if (!HasOpened)
        {
            userNamePrompt.SetActive(true);
        }
        
    }*/
    public void OnPlayPressed()
    {
        CarGarage.SetActive(true);
        HomePanel.SetActive(false);

    }

    public void OnShopBtnPressed()
    {
        shopPanel.SetActive(true);
    }

    public void OnRewardBtnPressed()
    {
      //  FindObjectOfType<GoogleAdMobController>().RequestAndLoadRewardedAd();

        //FindObjectOfType<GoogleAdMobController>().ShowRewardedAd();
    }

    public void RewardPlayer()
    {
        
        PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")+250);
       // Debug.Log("Coins"+ PlayerPrefs.GetInt("Coins") + 250);
    }

    public void onLeftShopbtnPressed()
    {
        if(currentItem > 0)
        {
            currentItem -= 1;
            for (int i = 0; i < shopItems.Length; i++)
            {
                shopItems[i].SetActive(false);
                shopItems[currentItem].SetActive(true);
            }
        }
    }

    public void onRightShopbtnPressed()
    {
        if (currentItem <shopItems.Length-1)
        {
            currentItem += 1;
            for (int i = 0; i < shopItems.Length; i++)
            {
                shopItems[i].SetActive(false);
                shopItems[currentItem].SetActive(true);
            }
        }
    }
    /*public void OnGaragebtnPressed()
    {
        SceneManager.LoadScene("Car Garage");
    }*/

    /* public void OnSubmit()
     {
         PlayerPrefs.SetString("Username", inputField.text);
         usernme.text = inputField.text;
         userNamePrompt.SetActive(false);
         HasOpened = true;

     }*/
}
