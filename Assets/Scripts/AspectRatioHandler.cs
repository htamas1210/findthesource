using System.Collections;
using System.Collections.Generic;
using System;
using System.IO; //ideiglenes amig a mac camera bug nincs javitva aztan torolheto
using System.Text; //ideiglenes
using UnityEngine;

public class AspectRatioHandler : MonoBehaviour
{
    public Camera mainCamera;
    private StreamWriter writer;


    private void Awake() {
        writer = new StreamWriter(Application.persistentDataPath + "/aspectratio.txt", false, Encoding.Default);

        double aspectRatio = (double)Screen.width / (double)Screen.height;
        aspectRatio = Math.Round(aspectRatio, 2);
        writer.Write("felbontas: width: " + Screen.width + " height: " + Screen.height + " aspectratio: " + aspectRatio+ "unity aspect: " + mainCamera.aspect);
        writer.Close();
        Debug.Log("aspectratio: " + aspectRatio);

        //5:4 1,25, 4:3 1,33, 16:9 1,77, 16:10 1,6, 21:9 2,33

        if(aspectRatio == 1.78 || aspectRatio == 2.33){
            if(Application.platform == RuntimePlatform.OSXPlayer)
                mainCamera.orthographicSize = 11.5f; //mac aspect ratio fix???
            else
                mainCamera.orthographicSize = 10.4f; //16:9, 21:9
        }else if(aspectRatio == 1.6){
            if(Application.platform == RuntimePlatform.OSXPlayer)
                mainCamera.orthographicSize = 11.5f; //mac aspect ratio fix???
            else
                mainCamera.orthographicSize = 11.43f; //16:9, 21:9 //16:10 11.43f
        }else if(aspectRatio == 1.33){
            mainCamera.orthographicSize = 13.72f; //4:3
        }else if(aspectRatio == 1.25){
            mainCamera.orthographicSize = 14.68f;
        }        
    }
}
