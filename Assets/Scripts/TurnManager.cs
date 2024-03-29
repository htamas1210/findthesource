using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private Dice dice;
    private Akciopont akciopont;
    private Energia energia;
    private Upgrade upgrade;
    private jatekmanager jatekmanager;

    public int turnCounter = 1;

    private void Awake()
    {
        dice = FindObjectOfType<Dice>();
        akciopont = FindObjectOfType<Akciopont>();
        energia = FindObjectOfType<Energia>();
        upgrade = FindObjectOfType<Upgrade>();
        jatekmanager = FindObjectOfType<jatekmanager>();

        dice.ujradobasszamlalo = upgrade.ujradobas[upgrade.getUjradobasIndex()] + 1;
        Debug.Log("ujradobasszamlalo: " + dice.ujradobasszamlalo);
    }

    public void nextTurn() {
        dice.setLocked(false);
        dice.dobottEgyszer = false;
        dice.hely1.sprite = null;
        dice.hely2.sprite = null;
        dice.ujradobasszamlalo = upgrade.ujradobas[upgrade.getUjradobasIndex()] + 1;
        dice.diceResult = new int[2];
        Debug.Log("ujradobasszamlalo: " + dice.ujradobasszamlalo);

        akciopont.resetAkciopont();

        energia.csokkenEnergia(upgrade.energia[upgrade.getEnergiaIndex()]);
        energia.granatAktivalva = false; //ha aktivalva lett a granat a korben deaktivalja
        
        turnCounter++;      
        
        jatekmanager.vanertelme = true;
        jatekmanager.JatekosVesztett();
        jatekmanager.JatekosNyert();
        
        if (jatekmanager.jatekosnyert == false && jatekmanager.jatekosvesztett == false)
        {
            jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.KorKezdet); //a jatekmanager atvalt a korkezdet eventre

            Debug.Log("kovetkezo kor " + turnCounter);
        }        
    }
}
