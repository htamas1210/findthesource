using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static jatekmanager;

public class TurnManager : MonoBehaviour
{
    private Dice dice;
    private Akciopont akciopont;
    private Energia energia;
    private Upgrade upgrade;
    private jatekmanager jatekmanager;

    public int turnCounter = 1;

    void Start()
    {
        dice = FindObjectOfType<Dice>();
        akciopont = FindObjectOfType<Akciopont>();
        energia = FindObjectOfType<Energia>();
        upgrade = FindObjectOfType<Upgrade>();
        jatekmanager = FindObjectOfType<jatekmanager>();
    }

    public void nextTurn() {
        dice.setLocked(false);
        akciopont.resetAkciopont();
        energia.csokkenEnergia(upgrade.energia[upgrade.getEnergiaIndex()]);
        energia.granatAktivalva = false; //ha aktivalva lett a granat a korben deaktivalja
        turnCounter++;
        dice.hely1.sprite = null;
        dice.hely2.sprite = null;
        jatekmanager.vanertelme = true;
        Debug.Log("kovetkezo kor " + turnCounter);
        jatekmanager.Instance.UpdateGameState(GameState.KorKezdet); //a jatekmanager atvalt a korkezdet eventre

        /*
          if (energiavesztese > 29)
        {
            jatekmanager.Instance.UpdateGameState(GameState.Vesztett); //a jatekmanager atvalt a vesztett eventre
        }
         */

        
    }
}
