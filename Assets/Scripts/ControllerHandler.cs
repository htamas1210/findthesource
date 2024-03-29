using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerHandler : MonoBehaviour
{
    //if controller movement is detected hide the cursor and and spawn a ui object to act as a cursor for controller

    [SerializeField] private bool connected = false;
    public string[] controllers;

    private IEnumerator detectControllers(){
        while(true){
            controllers = Input.GetJoystickNames();

            if(!connected && controllers.Length > 0){
                Debug.Log("Controller connected");
                for(int i = 0; i < controllers.Length; i++){
                    Debug.Log(controllers[i]);

                    //lock and disable mouse
                    //Cursor.lockState = CursorLockMode.locked;
                    //Cursor.visible = false;

                    //yield break;
                }
            }else if(connected && controllers.Length == 0){
                Debug.Log("disconnected / not connected");
            }else if(!connected && controllers.Length == 0){
                Debug.Log("not connected");
            }

            yield return new WaitForSecondsRealtime(5f); //check every 5 seconds
        }
    }

    private void Awake() {
        StartCoroutine(detectControllers());
    }
}
