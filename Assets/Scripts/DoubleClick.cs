using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class DoubleClick : MonoBehaviour
{
    private UnityEvent toDoubleClick; //event tarolo
    [SerializeField] private Button confirmDoubleClick;
    [SerializeField] private Button cancelDoubleClick;

    private MessageBox messageBox;

    private void Awake() {
        messageBox = FindObjectOfType<MessageBox>();
    }

    private void Start() {
        if(toDoubleClick == null){
            toDoubleClick = new UnityEvent();
        }
        //AddEvent(TestFV); //testing only
    }

    public void AddEvent(UnityAction function, bool emptyEvents = true){ //event hozzaadasa
        if(emptyEvents) RemoveFunctions(); //legyenek e torolve az eltarolt eventek

        toDoubleClick.AddListener(function);
    }

    public void RemoveFunctions(){ //eltarolt eventek torlese
        toDoubleClick.RemoveAllListeners();
    }

    public void ShowConfirmation(){//megerositeshez a dolgok megjelenitese | (string message)
        /*messageBox.ResetMessageBox();
        messageBox.SendMessageToBox(message); //uzenet ami a boxba jelenjek meg a usernek*/

        //confirmDoubleClick.onClick.AddListener(StartEvent); //a confirm gomb indidtsa el az eventet
        confirmDoubleClick.onClick.AddListener(ConfirmOnClicks);

        ShowButtons(true);
    }

    private void ConfirmOnClicks(){
        StartEvent();
        AfterInvoke();      
    }

    private void StartEvent(){
        toDoubleClick.Invoke();
    }

    private void AfterInvoke(){
        RemoveFunctions(); //event lista uritese miutan fel lett hasznalva
        confirmDoubleClick.onClick.RemoveAllListeners(); //gomb onclick torlese
        messageBox.ResetMessageBox(); //uzenet torlese
        ShowButtons(false);
    }

    public void TestFV(){
        Debug.Log("Test fv");
    }


    private void ShowButtons(bool show){
        confirmDoubleClick.gameObject.SetActive(show);
        cancelDoubleClick.gameObject.SetActive(show);
    }
}