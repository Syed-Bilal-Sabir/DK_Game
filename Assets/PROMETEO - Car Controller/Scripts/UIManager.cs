using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public int coins;
    public TMPro.TMP_Text CoinsTXT;
    private void Start()
    {
        if (FindObjectOfType<GoogleAdMobController>().interstitialAd != null)
        {
            FindObjectOfType<GoogleAdMobController>().ShowInterstitialAd();
        }
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
}
