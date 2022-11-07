using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private Dice dice;
    private Akciopont akciopont;

    public int turnCounter = 1;

    void Start()
    {
        dice = FindObjectOfType<Dice>();
        akciopont = FindObjectOfType<Akciopont>();

    }

    public void nextTurn() {
        dice.setLocked(false);
        akciopont.resetAkciopont();
        turnCounter++;
        dice.hely1.sprite = null;
        dice.hely2.sprite = null;
        Debug.Log("kovetkezo kor " + turnCounter);
    }

}
