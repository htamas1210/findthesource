using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AspectRatioHandler : MonoBehaviour
{
    public Camera mainCamera;

    private void Awake() {
        double aspectRatio = (double)Screen.width / (double)Screen.height;
        aspectRatio = Math.Round(aspectRatio, 2);
        Debug.Log("aspectratio: " + aspectRatio);

        //5:4 1,25, 4:3 1,33, 16:9 1,77, 16:10 1,6, 21:9 2,33

        if(aspectRatio == 1.78 || aspectRatio == 2.33){
            mainCamera.orthographicSize = 10.4f; //16:9, 21:9
        }else if(aspectRatio == 1.6){
            mainCamera.orthographicSize = 11.43f; //16:10
        }else if(aspectRatio == 1.33){
            mainCamera.orthographicSize = 13.72f; //4:3
        }else if(aspectRatio == 1.25){
            mainCamera.orthographicSize = 14.68f;
        }
        
    }
}
