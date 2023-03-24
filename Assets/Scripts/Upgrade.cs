using TMPro;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public readonly int[] energia = { 3, 3, 2, 2, 1 };
    public readonly int[] akcio = { 0, 0, 1, 1, 2 };
    public readonly int[] harc = { 1, 1, 2, 2, 3 };
    public readonly int[] ujradobas = { 0, 1, 2, 3, 4 };
    public readonly int[] hack = { 4, 3, 2, 1 };

    public TMP_Text[] energiatext;
    public TMP_Text[] akciotext;
    public TMP_Text[] harctext;
    public TMP_Text[] ujradobastext;
    public TMP_Text[] hacktext;

    public bool canUpgrade = false;

    private int energia_index, akcio_index, harc_index, ujradobas_index, hack_index = 0; //nem lehet nagyobb 4-nel | hack 3-nal
    public int fejlesztes_szamlalo = 0;

    public int getEnergiaIndex() { return energia_index; }
    public int getAkcioIndex() { return akcio_index; }
    public int getHarcIndex() { return harc_index; }
    public int getUjradobasIndex() { return ujradobas_index; }
    public int getHackIndex() { return hack_index; }

    public void upgradeEnergia() {
        if (canUpgrade) {
            if (energia_index < 4) {
                energiatext[energia_index].text = "X";
                energia_index++;
                canUpgrade = false;
                jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.Akcio); //a jatekmanager atvalt a korkezdet eventre
            }
            Debug.Log("energia_i: " + energia_index);
            fejlesztes_szamlalo++;
        }
    }

    public void upgradeAkcio() {
        if (canUpgrade) {
            if (akcio_index < 4) {
                akciotext[akcio_index].text = "X";
                akcio_index++;
                canUpgrade = false;
                jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.Akcio); //a jatekmanager atvalt a korkezdet eventre
            }
            Debug.Log("akcio_i: " + akcio_index);          
            fejlesztes_szamlalo++;
        }
    }

    public void upgradeHarc() {
        if (canUpgrade) {
            if (harc_index < 4) {
                harctext[harc_index].text = "X";
                harc_index++;
                canUpgrade = false;
                jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.Akcio); //a jatekmanager atvalt a korkezdet eventre
            }
            Debug.Log("harc_i: " + harc_index);        
            fejlesztes_szamlalo++;
        }
    }

    public void upgradeUjradobas() {
        if (canUpgrade) {
            if (ujradobas_index < 4) {
                ujradobastext[ujradobas_index].text = "X";
                ujradobas_index++;
                canUpgrade = false;
                jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.Akcio); //a jatekmanager atvalt a korkezdet eventre
            }
            Debug.Log("ujradobas_i: " + ujradobas_index);    
            fejlesztes_szamlalo++;
        }
    }

    public void upgradeHack() {
        if (canUpgrade) {
            if (hack_index < 3) {
                hacktext[hack_index].text = "X";
                hack_index++;
                canUpgrade = false;
                jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.Akcio); //a jatekmanager atvalt a korkezdet eventre
            }
            Debug.Log("hack_i: " + hack_index);           
            fejlesztes_szamlalo++;
        }
    }
}
