using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private Dice dice;
    private Akciopont akciopont;
    private Energia energia;
    private Upgrade upgrade;

    public int turnCounter = 1;

    void Awake()
    {
        dice = FindObjectOfType<Dice>();
        akciopont = FindObjectOfType<Akciopont>();
        energia = FindObjectOfType<Energia>();
        upgrade = FindObjectOfType<Upgrade>();
    }

    public void nextTurn() {
        dice.setLocked(false);
        dice.dobottEgyszer = false;
        akciopont.resetAkciopont();
        energia.csokkenEnergia(upgrade.energia[upgrade.getEnergiaIndex()]);
        energia.granatAktivalva = false; //ha aktivalva lett a granat a korben deaktivalja
        turnCounter++;
        dice.hely1.sprite = null;
        dice.hely2.sprite = null;
        Debug.Log("kovetkezo kor " + turnCounter);
    }
}
