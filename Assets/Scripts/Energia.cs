using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Energia : MonoBehaviour
{
    public TMP_Text[] energiasav_text;
    private int energiasav_index = 0;
    public bool granatAktivalva = false;

    private jatekmanager jatekmanager;

    public int getEnergiasavIndex() { return energiasav_index; }
    public void setEnegiasavIndex(int ertek) { energiasav_index = ertek; }

    public void csokkenEnergia(int number) {
        if (granatAktivalva) {
            granatAktivalva = false;
            return; //targy cucc aktivalva egesz korbe nem csokken az energia
        }

        if (energiasav_index > 29) {
            jatekmanager.Instance.jatekosvesztett = true;
            jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.Vesztette); 
            //ha nincs tobb energia vesztes
        }

        for (int i = 0; i < number; i++) {
            //if (number + enegiasav_index > energiasav_text.Length) break;
            if (energiasav_index >= 30) {
                energiasav_index = 29;
                break;
            }

            energiasav_text[getEnergiasavIndex()].text = "X";
            setEnegiasavIndex(getEnergiasavIndex() + 1);
        }      

        Debug.Log("energia csokkent");
    }
}
