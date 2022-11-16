using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuQuit : MonoBehaviour
{
    public void QuitGame() {
        Debug.Log("Application is quitting!!");
        Application.Quit();
    }
}
