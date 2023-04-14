using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollisionDetection : MonoBehaviour
{
    public GameObject gameoverPanel;
    public GameObject controls;
    public TMP_Text Scorelabel;
    private void Start()
    {
        
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Destroyers"))
        {
            FindObjectOfType<PrometeoCarController>().IsMovingFwd = false;
            FindObjectOfType<PrometeoCarController>().maxSpeed = 0;
            FindObjectOfType<Rigidbody>().drag = 100f;
            FindObjectOfType<PrometeoCarController>().useSounds = false;
            Scorelabel.text=FindObjectOfType<PrometeoCarController>().RoundedScore.ToString();
            controls.SetActive(false);
            StartCoroutine("ReqandLoadAd");
           
        }
    }
    IEnumerator ReqandLoadAd()
    {
        yield return new WaitForSeconds(.1f);
        gameoverPanel.SetActive(true);
        //if (FindObjectOfType<GoogleAdMobController>().interstitialAd != null &&PlayerPrefs.GetInt("RemoveAds")!=1)
        //{
        //    FindObjectOfType<GoogleAdMobController>().ShowInterstitialAd();
        //}
    }
}
