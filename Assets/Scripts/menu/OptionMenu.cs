using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    //Resolution
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;

    private void Start() {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResIndex = 0;

        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " +  resolutions[i].height + " @"+resolutions[i].refreshRate;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) {
                currentResIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResIndex;
        //resolutionDropdown.itemText.fontSize = 18;
        resolutionDropdown.RefreshShownValue();
    }

    public void setResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //Quality
    public void setQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    //Fullscreen
    public void setFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }

    /*public void setVsync(bool value) {
        int num = 0;

        if (value) num = 1;
        else num = 0;

        if (num > 0) Debug.Log("vsync on");
        else Debug.Log("vsync off");

        QualitySettings.vSyncCount = num;
    }*/
}
