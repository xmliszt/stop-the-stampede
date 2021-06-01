using UnityEngine;

public class SwitchDayNight : MonoBehaviour
{
    public Material daySkyBox;
    public Material nightSkyBox;
    public GameObject theSun;
    public GameObject theMoon;
    public Light playerTorchLight;

    private void Awake()
    {
        string sky = PlayerPrefs.GetString("sky", "day");
        if (sky == "day")
        {
            SwitchToDay();
        } else
        {
            SwitchToNight();
        }
    }

    public void SwitchToDay()
    {
        RenderSettings.skybox = daySkyBox;
        RenderSettings.fogColor = Color.grey;
        RenderSettings.sun.intensity = 1;
        playerTorchLight.enabled = false;
        PlayerPrefs.SetString("sky", "day");
        theSun.SetActive(true);
        theMoon.SetActive(false);
    }

    public void SwitchToNight()
    {
        RenderSettings.skybox = nightSkyBox;
        RenderSettings.fog = false;
        RenderSettings.fogColor = new Color(0.5f, 0.36f, 0.5f, 1.0f);
        RenderSettings.fog = true;
        RenderSettings.sun.intensity = 0.1f;
        playerTorchLight.enabled = true;
        PlayerPrefs.SetString("sky", "night");
        theSun.SetActive(false);
        theMoon.SetActive(true);
    }
}
