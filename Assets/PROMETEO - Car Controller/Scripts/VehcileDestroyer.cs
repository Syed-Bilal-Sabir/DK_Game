using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehcileDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerVehicle"))
        {
            Debug.Log(other.gameObject.name);
        }
    }
}
