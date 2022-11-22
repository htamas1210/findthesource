using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class helyszinaktivalas : MonoBehaviour
{
    private Elet elet;
    private Akciok akciok;
    private Targyak targyak;
    private Dice dice;
    private Upgrade upgrade;
    private Akciopont akciopont;
    private movement movement;
    //int movement.jelenlegi_x;
    //int movement.movement.jelenlegi_y;
    bool canUpgrade = false;
    private int diceResult;
    public Sprite[] diceSides = new Sprite[6];
    public SpriteRenderer hely1;

    // Start is called before the first frame update
    void Start()
    {
        dice = FindObjectOfType<Dice>();
        akciopont = FindObjectOfType<Akciopont>();
        movement = FindObjectOfType<movement>();
        upgrade = FindObjectOfType<Upgrade>();
        targyak = FindObjectOfType<Targyak>();
        akciok = FindObjectOfType<Akciok>();
        elet = FindObjectOfType<Elet>();
    }

    // Update is called once per frame
    /*void Update()
    {
        movement.jelenlegi_x = movement.jelenlegi_x;
        movement.jelenlegi_y = movement.jelenlegi_y;
        canUpgrade = false;
    }*/

    public void HelyszinAktivalas()
    {
        //1-es mezõ
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 1)
        {
            //ügynökcsapat ölés bárhol töltény nélkül
        }
        //2-es mezõ -- KÉSZ
        if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 1)
        {
            canUpgrade = true;
            akciopont.akciopont++;
        }
        //3-es mezõ -- KÉSZ
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 1)
        {
            movement.helyreTeleport();
        }
        //4-es mezõ
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 2)
        {
            //kapsz egy tárgyat
        }
        //5-es mezõ
        if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 2)
        {
            /*diceResult = RollDice();
            hely1.sprite = diceSides[diceResult - 1];
            hely1.size = new Vector2(38, 38);
            targyak.targy_szamlalo++;*/
        }
        //6-es mezõ
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 2)
        {
            //+1 akció
        }
        //7-es mezõ -- KÉSZ
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 3)
        {
            //1 fejlesztés ingyen
            canUpgrade = true;
            akciopont.akciopont++;
        }
        //8-es mezõ
        if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 3)
        {

            /*diceResult = RollDice();
            hely1.sprite = diceSides[diceResult - 1];
            hely1.size = new Vector2(38, 38);
            targyak.targy_szamlalo++;*/

        }
        //9-es mezõ -- KÉSZ
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 3)
        {
            targyak.RandomTargy();
            targyak.targy_szamlalo++;
        }
        //10-es mezõ -- KÉSZ ?
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 4)
        {
            //+4 töltény
            akciok.Betarazas(4);
        }
        //11-es mezõ
        if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 4)
        {
            //Dobj! Megkapod a tárgyat.
            
           /* diceResult = RollDice();
            hely1.sprite = diceSides[diceResult - 1];
            hely1.size = new Vector2(38, 38);
            targyak.targy_szamlalo++;*/
        }
        //12-es mezõ  -- KÉSZ
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 4)
        {
            //+1 élet
            elet.Eletplusz();
        }
    }


    /*private int RollDice()
    {
        int randomDiceSide = UnityEngine.Random.Range(0, 5);
        int finalSide = randomDiceSide + 1;

        Debug.Log(finalSide);

        return finalSide;
    }*/
}
