using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static jatekmanager;

public class Dice : MonoBehaviour {
    public Sprite[] diceSides = new Sprite[6];
    public SpriteRenderer hely1;
    public SpriteRenderer hely2;

    private Upgrade upgrade;
    private Akciopont ap;
    private Energia energiasav;
    private Targyak targyak;

    public int[] diceResult = { 0, 0 };
    public int[] ujertek;
    public int valasztottErtek; //a jatekos altal valasztott dobott ertek helye
    private bool locked = false; //ne lehessen ujra kivalasztani a masikat ha mar tortent egy valasztas
    
    public bool adrenalinMegerosites = false;
    public GameObject adrenalinHasznalat;
    public Button confirm;
    public Button cancel;

    public GameObject rolldice;


    public BoxCollider2D[] colliders;

    //getters setters
    public int[] getDices() { return diceResult; }
    public int getValasztottErtek() { return valasztottErtek; }
    public void setValasztottErtek(int ujErtek) { valasztottErtek = ujErtek; }
    public bool getLocked() { return locked; }
    public void setLocked(bool locked) { this.locked = locked; }

    public int dobott = 0;

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
                    jatekmanager.Instance.UpdateGameState(GameState.Fejlesztes); //a jatekmanager atvalt a fejlesztes eventre
                } else {
                    energiasav.csokkenEnergia(1); //nagyobb szam valasztasa eseten -1 energia
                    jatekmanager.Instance.UpdateGameState(GameState.Akcio); //a jatekmanager atvalt az akcio eventre
                }

                locked = true;
            } else if (gomb.name == "dice2btn") {
                valasztottErtek = diceResult[1];
                if (diceResult[1] < diceResult[0]) {
                    upgrade.canUpgrade = true;
                    jatekmanager.Instance.UpdateGameState(GameState.Fejlesztes); //a jatekmanager atvalt a fejlesztes eventre
                } else {
                    energiasav.csokkenEnergia(1);
                    jatekmanager.Instance.UpdateGameState(GameState.Akcio); //a jatekmanager atvalt az akcio eventre
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

        dobott++;
        Debug.Log("Ennyit dobtál: " + dobott);
        Debug.Log("Ennyi dobásod van még: " + ((upgrade.getUjradobasIndex() + 1) - dobott));

        //jatemanager reszere
        if (dobott < upgrade.getUjradobasIndex() + 1)
        {
            Debug.Log(dobott);
        }
        else
        {
            rolldice.SetActive(false);
            Debug.Log("Nincs több dobásod a körben");
        }


        if (targyak.adrenalinloket > 0) {
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
                Debug.Log("belep");
                targyak.CallAdrenalinLoket();
                diceResult[0] = ujertek[0];
                diceResult[1] = ujertek[1];
            }
            //deaktivalas
            Debug.Log("belep2");
            adrenalinMegerosites = false;
            HelyszinKiBekapcs(false);
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
    
    public IEnumerator waitbutton(){
        Debug.Log("belep wait");
        var waitForButton = new WaitForUIButtons(confirm, cancel);
            yield return waitForButton.Reset();

            if(waitForButton.PressedButton == confirm){
                adrenalinMegerosites = true;
            }else{
                adrenalinMegerosites = false;
            }

        adrenalinHasznalat.gameObject.SetActive(false);
    }

    public void setAdrenalinMegerosites(bool adrenalinMegerosites) {
        this.adrenalinMegerosites = adrenalinMegerosites; 
    }
}
