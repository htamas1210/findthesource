using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {
    public Sprite[] diceSides = new Sprite[6];
    public SpriteRenderer hely1;
    public SpriteRenderer hely2;
    //public SpriteRenderer akcioponthely;

    private Upgrade upgrade;
    private Akciopont ap;
    private Energia energiasav;

    private int[] diceResult = { 0, 0 };
    public int valasztottErtek; //a jatekos altal valasztott dobott ertek helye
    private bool locked = false; //ne lehessen ujra kivalasztani a masikat ha mar tortent egy valasztas

    //getters setters
    public int[] getDices() { return diceResult; }
    public int getValasztottErtek() { return valasztottErtek; }
    public void setValasztottErtek(int ujErtek) { valasztottErtek = ujErtek; }
    public bool getLocked() { return locked; }
    public void setLocked(bool locked) { this.locked = locked; }

    private void Start() {
        upgrade = FindObjectOfType<Upgrade>();
        ap = FindObjectOfType<Akciopont>();
        energiasav = FindObjectOfType<Energia>();
    }


    public void ertekValasztas(GameObject gomb) {
        if (diceResult[0] != 0 && diceResult[1] != 0 && !locked) { //megnezzuk hogy lett e mar dobva es nem valasztott meg a jatekos
            if (gomb.name == "dice1btn") {
                valasztottErtek = diceResult[0];
                if (diceResult[0] < diceResult[1]) {
                    upgrade.canUpgrade = true; //kisebb szam valasztasa eseten fejlesztes egyszer
                } else {
                    energiasav.csokkenEnergia(1); //nagyobb szam valasztasa eseten -1 energia
                }

                //a valasztott szam atirasa az akcio mezobe
                /*akcioponthely.sprite = diceSides[valasztottErtek-1];
                akcioponthely.size = new Vector2(38, 38);*/

                locked = true;
            } else if (gomb.name == "dice2btn") {
                valasztottErtek = diceResult[1];
                if (diceResult[1] < diceResult[0]) {
                    upgrade.canUpgrade = true;
                } else {
                    energiasav.csokkenEnergia(1);
                }

                //a valasztott szam atirasa az akcio mezobe
                /*akcioponthely.sprite = diceSides[valasztottErtek-1];
                akcioponthely.size = new Vector2(38, 38);
                */
                locked = true;
            }

            ap.UpdateAkciopont(getValasztottErtek() + upgrade.akcio[upgrade.getAkcioIndex()]);
        }

        Debug.Log("valasztott ertek: " + valasztottErtek + " locked status: " + locked);
    }

    public int RollDice() {
        int randomDiceSide = Random.Range(0, 5);
        int finalSide = randomDiceSide + 1;

        Debug.Log(finalSide);

        return finalSide;
    }

    public void renderDice() {
        do {
            diceResult[0] = RollDice();
            diceResult[1] = RollDice();
        } while (diceResult[0] == diceResult[1]);

        hely1.sprite = diceSides[diceResult[0]-1];
        hely1.size = new Vector2(38, 38);

        hely2.sprite = diceSides[diceResult[1]-1];
        hely2.size = new Vector2(38, 38);
    }
}
