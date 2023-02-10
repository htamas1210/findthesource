using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour {
    public Sprite[] diceSides = new Sprite[6];
    public SpriteRenderer hely1;
    public SpriteRenderer hely2;

    private Upgrade upgrade;
    private Akciopont ap;
    private Energia energiasav;
    private Targyak targyak;

    public int[] diceResult = { 0, 0 };
    public List<int> ujertek = new List<int>();
    public int valasztottErtek; //a jatekos altal valasztott dobott ertek helye
    private bool locked = false; //ne lehessen ujra kivalasztani a masikat ha mar tortent egy valasztas
    
    public bool adrenalinMegerosites = false;
    public GameObject adrenalinHasznalat;
    public Button confirm;
    public Button cancel;  
    public bool mehet = false;


    public BoxCollider2D[] colliders;

    //getters setters
    public int[] getDices() { return diceResult; }
    public int getValasztottErtek() { return valasztottErtek; }
    public void setValasztottErtek(int ujErtek) { valasztottErtek = ujErtek; }
    public bool getLocked() { return locked; }
    public void setLocked(bool locked) { this.locked = locked; }

    public int dobott = 0;

    private void Awake() {
        
    }

    private void Start() {
        upgrade = FindObjectOfType<Upgrade>();
        ap = FindObjectOfType<Akciopont>();
        energiasav = FindObjectOfType<Energia>();
        targyak = FindObjectOfType<Targyak>();
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

                locked = true;
            } else if (gomb.name == "dice2btn") {
                valasztottErtek = diceResult[1];
                if (diceResult[1] < diceResult[0]) {
                    upgrade.canUpgrade = true;
                } else {
                    energiasav.csokkenEnergia(1);
                }

                locked = true;
            }

            ap.UpdateAkciopont(getValasztottErtek() + upgrade.akcio[upgrade.getAkcioIndex()]);
        }

        Debug.Log("valasztott ertek: " + valasztottErtek + " locked status: " + locked);
    }

    public int RollDice() {
        int randomDiceSide = Random.Range(0, 6);
        int finalSide = randomDiceSide + 1;

        Debug.Log(finalSide);

        return finalSide;
    }

    public void CallRenderDice() => StartCoroutine(renderDice());

    public IEnumerator renderDice() {
        do {
            diceResult[0] = RollDice();
            diceResult[1] = RollDice();
        } while (diceResult[0] == diceResult[1]);

        //lassa a jatekos mit dobott
        hely1.sprite = diceSides[diceResult[0]-1];
        hely1.size = new Vector2(38, 38);

        hely2.sprite = diceSides[diceResult[1]-1];
        hely2.size = new Vector2(38, 38);

        //ha megvan a targy
        if(targyak.adrenalinloket > 0) {
            //helyszin collider kikapcsolas a gomb miatt
            HelyszinKiBekapcs(true);
            //text aktivalasa kerdesre hogy akarja e hasznalni a targyat
            adrenalinHasznalat.gameObject.SetActive(true);                    
            //ha igen gomb -> valtozo igaz, targy fv meghivas, deaktivalas
            //VARNIA KELL A GOMBRA
            var waitForButton = new WaitForUIButtons(confirm, cancel);
            yield return waitForButton.Reset();

            if(waitForButton.PressedButton == confirm){
                adrenalinMegerosites = true;
            }else{
                adrenalinMegerosites = false;
            }

            adrenalinHasznalat.gameObject.SetActive(false);

            if (adrenalinMegerosites) {
                //Debug.Log("belep");
                targyak.CallAdrenalinLoket();
                yield return new WaitUntil(() => ujertek.Count > 0);
                if(mehet){
                    Debug.Log("belep mehet");
                    Debug.Log("List: 0: " + ujertek[0] + " 1: " + ujertek[1]);
                    //ha tul nagy vagy tul kicsi erteket ad meg az elso kockanak valtsa at az erteket
                    if(targyak.ujertek1 > 6 && diceResult[1] != 6 && targyak.ujertek2 != 6){ //ha tul nagy szamot adott meg legyen 6 az ertek
                        targyak.ujertek1 = 6;
                    }else if(targyak.ujertek1 > 6 && (diceResult[1] == 6 || targyak.ujertek2 == 6)){ //ha a masik ertek 6 akkor legyen az ertek 5
                        targyak.ujertek1 = 5;
                    }else if(targyak.ujertek1 < 1 && diceResult[1] != 1 && targyak.ujertek2 != 1){
                        targyak.ujertek1 = 1;
                    }else if(targyak.ujertek1 < 1 && (diceResult[1] == 1 || targyak.ujertek2 == 1)){
                        targyak.ujertek1 = 2;
                    }

                    //

                    //ha tul nagy vagy tul kicsi erteket ad meg az masodik kockanak valtsa at az erteket
                    if(targyak.ujertek2 > 6 && diceResult[0] != 6 && targyak.ujertek1 != 6){ //ha tul nagy szamot adott meg legyen 6 az ertek
                        targyak.ujertek2 = 6;
                    }else if(targyak.ujertek2 > 6 && (diceResult[0] == 6 || targyak.ujertek1 == 6)){ //ha a masik ertek 6 akkor legyen az ertek 5
                        targyak.ujertek2 = 5;
                    }else if(targyak.ujertek2 < 1 && diceResult[0] != 1 && targyak.ujertek1 != 1){
                        targyak.ujertek2 = 1;
                    }else if(targyak.ujertek2 < 1 && (diceResult[0] == 1 || targyak.ujertek1 == 1)){
                        targyak.ujertek2 = 2;
                    }

                    

                    diceResult[0] = targyak.ujertek1;
                    diceResult[1] = targyak.ujertek2;
                }        
            }
            //deaktivalas
            Debug.Log("belep2");
            adrenalinMegerosites = false;
            //HelyszinKiBekapcs(false);
        }

        hely1.sprite = diceSides[diceResult[0]-1];
        hely1.size = new Vector2(38, 38);

        hely2.sprite = diceSides[diceResult[1]-1];
        hely2.size = new Vector2(38, 38);
        dobott++;
    }

    public void HelyszinKiBekapcs(bool kikapcsolas){
        if(kikapcsolas)
            foreach(var item in colliders)
                item.gameObject.SetActive(false);          
        else
            foreach(var item in colliders)
                item.gameObject.SetActive(true);            
    }

    public void setAdrenalinMegerosites(bool adrenalinMegerosites) {
        this.adrenalinMegerosites = adrenalinMegerosites; 
    }
}
