using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public int coins;
    public TMPro.TMP_Text CoinsTXT;
    public GameObject RateUsPanel;
    private void Start()
    {
        //if (FindObjectOfType<GoogleAdMobController>().interstitialAd != null)
        //{
        //    FindObjectOfType<GoogleAdMobController>().ShowInterstitialAd();
        //}
    }
    public void OnMainMenuePressed()
    {
        SceneManager.LoadSceneAsync("Home");
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + coins);
    }
    public void SetCoins()
    {
        coins += 10;
        CoinsTXT.text = coins.ToString();
    }
    public void OnReplayPressed()
    {
        //Debug.Log("ccc");
        //Time.timeScale = 1;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + coins);
    }
    public void RateUs()
    {
#if UNITY_ANDROID
        Application.OpenURL("market://details?id=com.portseagames.Drift-King2.0");

#elif UNITY_IOS
        Application.OpenURL("itms-apps://itunes.apple.com/app/idcom.portseagames.Drift-King2.0");
#endif

        RateUsPanel.SetActive(false);

    }
    public void Later()
    {
        RateUsPanel.SetActive(false);
    }
}
