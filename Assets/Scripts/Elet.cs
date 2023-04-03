using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Elet : MonoBehaviour
{
    public TMP_Text[] elet_text;
    public int elet = 2;
    private int elet_vesztve = 0;
    private int elet_megszerezve = 2;
    private jatekmanager jatekmanager;

    private void Awake() {
        jatekmanager = FindObjectOfType<jatekmanager>();
    }

    private void Start() {
        for (int i = 0; i < elet_megszerezve; i++) {
            elet_text[i].text = "O";
        }
    }

    private void Update() {
        if(elet == 0){
            jatekmanager.Instance.jatekosvesztett = true;
        }
    }

    public void Eletplusz() {
        if (elet > 4) return;
        if (elet_megszerezve > 4) return;
        
        
        elet++;
        elet_megszerezve++;

        for (int i = elet_vesztve; i < elet_megszerezve; i++) {
            elet_text[i].text = "O";
        }
        /*Debug.Log("eletmegszerezve: " + elet_megszerezve);
        Debug.Log("elet: " + elet);*/
    }

    public void Eletvesztes() {
        if (elet_vesztve > 4)
        {
            //jatekmanager.jatekosvesztett = true;
            return;
         }
        if (elet_megszerezve > elet +1) return;
        //if(elet < 0) return;

        elet_vesztve++;
        elet--;

        for (int i = 0; i < elet_vesztve; i++) {
            elet_text[i].text = "X";
        }
    }
}
