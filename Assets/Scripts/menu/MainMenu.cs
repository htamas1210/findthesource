using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuObj;
    public GameObject OptionsMenu;
    public GameObject VideoButton;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Application is quitting!!");
        Application.Quit();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OptionMenu()
    {
        MainMenuObj.SetActive(false); //kikapcsolni a fomenu dolgokat
        OptionsMenu.SetActive(true); //bekapcsolni a beallitas menu dolgokat

        //megvizsgalni hogy a platform szamitogep, es ha nem csak a hangerot lehessen allitani
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.LinuxPlayer || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.LinuxEditor)
        {
            VideoButton.SetActive(true);
        }
    }
}
