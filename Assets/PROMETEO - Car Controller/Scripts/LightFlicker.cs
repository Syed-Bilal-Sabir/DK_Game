using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public float minIntensity = 0.25f;
    public float maxIntensity = 0.5f;
    public float flickerSpeed = 0.1f;

    private float targetIntensity;
    private float currentIntensity;

    void Start()
    {
        currentIntensity = GetComponent<Light>().intensity;
        targetIntensity = Random.Range(minIntensity, maxIntensity);
    }

    void Update()
    {
        currentIntensity = Mathf.Lerp(currentIntensity, targetIntensity, flickerSpeed * Time.deltaTime);
        GetComponent<Light>().intensity = currentIntensity;

        if (Mathf.Abs(currentIntensity - targetIntensity) < 0.01f)
        {
            targetIntensity = Random.Range(minIntensity, maxIntensity);
        }
    }
}