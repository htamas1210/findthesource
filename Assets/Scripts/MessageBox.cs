using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageBox : MonoBehaviour
{
    [SerializeField] private TMP_Text messageBox;

    public void SendMessageToBox(string message){
        messageBox.text = message;
    }

    public void ResetMessageBox(){
        messageBox.text = "";
    }
}
