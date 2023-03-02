using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    float rotatingSpeed = 10f;
    //public GameObject[] spawnPts;
  


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up*rotatingSpeed*Time.deltaTime);
    }
    /*public void OnDrawGizmos()
    {
        for (int i=0;i<spawnPts.Length;i++)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(spawnPts[i].transform.position,2f);
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerCar"))
        {
            gameObject.SetActive(false);
            FindObjectOfType<UIManager>().SetCoins();
        }
    }
}
