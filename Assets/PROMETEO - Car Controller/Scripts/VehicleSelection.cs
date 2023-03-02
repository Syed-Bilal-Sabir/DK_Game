using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VehicleSelection : MonoBehaviour
{

    public GameObject[] Cars;
    public int[] CarsPrice;
    int currentCar;
    float RotationSpeed = 10f;
    public bool inGamePlayScene=false;
    public Button Select;
    public Button Purchase;
    public TMPro.TMP_Text Coins;
    void Start()
    {
        if (!PlayerPrefs.HasKey("CarState0"))
        {
            
            PlayerPrefs.SetInt("CarState" + 0, 1);
            for (int i = 1; i < Cars.Length; i++)
            {
                PlayerPrefs.SetInt("CarState" + i, 0);
            }
        }

        int selectedcar = PlayerPrefs.GetInt("SelectedCarId");
        currentCar = 0;
        if (inGamePlayScene)
        {
            Cars[selectedcar].SetActive(true);
            currentCar = selectedcar;
        }
        if (SceneManager.GetActiveScene().name== "Home")
        {
            foreach (var car in Cars)
            {
                car.GetComponent<PrometeoCarController>().enabled = false;
            }
        }
        else
        {
            foreach (var car in Cars)
            {
                car.GetComponent<PrometeoCarController>().enabled = true;
            }
        }
        if (SceneManager.GetActiveScene().name=="Mobile Devices Demo")
        {
            GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>().carTransform = Cars[currentCar].transform;
        }
    }
    private void OnEnable()
    {
        if (!PlayerPrefs.HasKey("Coins"))
        {
            PlayerPrefs.SetInt("Coins", 1000);
        }

        if (!inGamePlayScene)
        {
            Coins.text = PlayerPrefs.GetInt("Coins").ToString();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!inGamePlayScene)
            Coins.text = PlayerPrefs.GetInt("Coins").ToString();
        if (SceneManager.GetActiveScene().name=="Home")
        {
            VehicleRotate();
        }

        if (!inGamePlayScene)
        {
            if (PlayerPrefs.GetInt("CarState" + currentCar) == 1)
            {
                Select.gameObject.SetActive(true);
                Purchase.gameObject.SetActive(false);
            }
            else
            {
                Select.gameObject.SetActive(false);
                Purchase.gameObject.SetActive(true);
                Purchase.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text = CarsPrice[currentCar].ToString();
            }
        }
    }

    public void OnRightPressed()
    {
        if (currentCar<Cars.Length-1)
        {
            currentCar += 1;
            for (int i=0;i<Cars.Length;i++)
            {
                Cars[i].SetActive(false);
                Cars[currentCar].SetActive(true);
            }
        }
    }

    public void OnLeftPressed()
    {
        if (currentCar > 0)
        {
            currentCar -= 1;
            for (int i = 0; i < Cars.Length; i++)
            {
                Cars[i].SetActive(false);
                Cars[currentCar].SetActive(true);
            }
        }
    }
    public void OnSelectPressed()
    {
        PlayerPrefs.SetInt("SelectedCarId",currentCar);
        SceneManager.LoadSceneAsync(1);

    }
    public void OnPurchasePressed()
    {
        if (PlayerPrefs.GetInt("Coins") >= CarsPrice[currentCar])
        {
            PlayerPrefs.SetInt("CarState" + currentCar, 1);
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins")- CarsPrice[currentCar]);
        }
        Select.gameObject.SetActive(true);
        Purchase.gameObject.SetActive(false);
    }
    private void VehicleRotate()
    {
        transform.Rotate(Vector3.up*RotationSpeed*Time.deltaTime);

    }
}
