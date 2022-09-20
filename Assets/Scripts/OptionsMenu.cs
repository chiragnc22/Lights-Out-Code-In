using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    public GameObject optionMenu;
    public GameObject optionButton;
    public static bool IsOptionMenuEnabled = false;


    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume",volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void showOptions()
    {
        optionMenu.SetActive(true);
        optionButton.SetActive(false);
        IsOptionMenuEnabled = true;
        Debug.Log(System.DateTime.Now);
        Time.timeScale = 0f;
        Debug.Log(System.DateTime.Now);
        Debug.Log(Time.realtimeSinceStartup);

    }

    public void CloseOptions()
    {
        optionMenu.SetActive(false);
        optionButton.SetActive(true);
        IsOptionMenuEnabled = false;
        Time.timeScale = 1f;
        Debug.Log(Time.realtimeSinceStartup);

    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape))
        {   if(IsOptionMenuEnabled){ 
                CloseOptions();
               }
            else{
                showOptions();
            }
    }       
    }
}
