using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject AdMob;


    void Start()
    {

#if UNITY_ANDROID
        AdMob.SetActive(true);
#endif

    }

    
}
