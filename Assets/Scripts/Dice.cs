using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour {
    public Sprite[] diceSides = new Sprite[6];
    public SpriteRenderer hely1;
    public SpriteRenderer hely2;
    [SerializeField] private int spriteSize = 60;
    private Vector2 diceSpriteSize;
    
    public Button dice1btnBtn; 
    public Button dice2btnBtn; 

    private Upgrade upgrade;
    private Akciopont ap;
    private Energia energiasav;
    private Targyak targyak;
    private Ugynok ugynok;
    private movement movement;

    public int[] diceResult = { 0, 0 };
    public List<int> ujertek = new List<int>();
    public int valasztottErtek; //a jatekos altal valasztott dobott ertek helye
    [SerializeField] private bool locked = false; //ne lehessen ujra kivalasztani a masikat ha mar tortent egy valasztas  
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
    public bool dobottEgyszer = false; //tudjon ujra dobni vagy nem
    public int ujradobasszamlalo;

    [SerializeField] private bool ugynokDobasErtek = false; //ertek valasztashoz hogy tudja az ugynok csapat miatt lett meghivva
    private bool elsoDobas = true;
    private void Awake() {
        upgrade = FindObjectOfType<Upgrade>();
        ap = FindObjectOfType<Akciopont>();
        energiasav = FindObjectOfType<Energia>();
        targyak = FindObjectOfType<Targyak>();
        ugynok = FindObjectOfType<Ugynok>();
        movement = FindObjectOfType<movement>();

        diceSpriteSize = new Vector2(spriteSize, spriteSize);
    }

    public void ertekValasztas(GameObject gomb) {
        if (diceResult[0] != 0 && diceResult[1] != 0 && !locked) { //megnezzuk hogy lett e mar dobva es nem valasztott meg a jatekos
            if (gomb.name == "dice1btn") {
                valasztottErtek = diceResult[0];
                if (diceResult[0] < diceResult[1]) {
                    if(!ugynokDobasErtek){
                        upgrade.canUpgrade = true; //kisebb szam valasztasa eseten fejlesztes egyszer
                        //locked = true;
                        jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.Fejlesztes);
                    }else{
                        //ugynok csapat szama
                        ugynok.UgynokSorsolas(movement.jelenlegi_x, movement.jelenlegi_y, valasztottErtek);

                        //-1 energia
                        energiasav.csokkenEnergia(1);
                        jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.Akcio);
                    }                 
                } else {
                    if(!ugynokDobasErtek){
                        energiasav.csokkenEnergia(1); //nagyobb szam valasztasa eseten -1 energia
                        jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.Akcio);
                        //locked = true;
                    }else{
                        //ugynok csapat szama
                        ugynok.UgynokSorsolas(movement.jelenlegi_x, movement.jelenlegi_y, valasztottErtek);
                        jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.Akcio);
                    }                    
                }
                //if(!ugynokDobasErtek)
                    locked = true;

            } else if (gomb.name == "dice2btn") {
                valasztottErtek = diceResult[1];
                if (diceResult[1] < diceResult[0]) {
                    if(!ugynokDobasErtek){
                        upgrade.canUpgrade = true; //kisebb szam valasztasa eseten fejlesztes egyszer
                        //locked = true;
                        jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.Fejlesztes);
                    }else{
                        //ugynok csapat szama
                        ugynok.UgynokSorsolas(movement.jelenlegi_x, movement.jelenlegi_y, valasztottErtek);
                        //-1 energia
                        energiasav.csokkenEnergia(1);
                        
                        jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.Akcio);
                    } 
                } else {
                    if(!ugynokDobasErtek){
                        energiasav.csokkenEnergia(1); //nagyobb szam valasztasa eseten -1 energia
                        //locked = true;
                        jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.Akcio);
                    }else{
                        //ugynok csapat szama
                        ugynok.UgynokSorsolas(movement.jelenlegi_x, movement.jelenlegi_y, valasztottErtek);                                        
                        jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.Akcio);
                    } 
                }

                //if(!ugynokDobasErtek)
                    locked = true;
            }

            if(!ugynokDobasErtek)
                ap.UpdateAkciopont(getValasztottErtek() + upgrade.akcio[upgrade.getAkcioIndex()]);
            else{
                ugynokDobasErtek = false;
                setLocked(false); 
            }
                
            dice1btnBtn.interactable = false;
            dice2btnBtn.interactable = false;  

            /*if(elsoDobas){
                //jatek kezdeskor elso dobas ugynok csapat meghatarozas kezdo helyszinen
                jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.UgynokValasztas);
                CallRenderDice(true);
                elsoDobas = false;
            }*/
        }

        Debug.Log("valasztott ertek: " + valasztottErtek + " locked status: " + locked);
    }

    public int RollDice() {
        int randomDiceSide = Random.Range(0, 6);
        int finalSide = randomDiceSide + 1;

        Debug.Log(finalSide);

        return finalSide;
    }

    public void CallRenderDice(bool ugynokDobas) => StartCoroutine(renderDice(ugynokDobas));

    public IEnumerator renderDice(bool ugynokDobas) {
        //ha zarolva van akkor ne tudjon ujra dobni / csak egyszer dobhasson (amig nincs feloldva a kovetkezo dobashoz)
        //ha ugynok miatt kell dobni mikor mar nincs ujradobas tudjon dobni
        if(dobottEgyszer && !ugynokDobas) yield break;

        //dice gombok kikapcsolasa hogy amig nem vegez ne tudjon erteket valasztani
        dice1btnBtn.enabled = false;
        dice2btnBtn.enabled = false;       

        do {
            diceResult[0] = RollDice();
            diceResult[1] = RollDice();
        } while (diceResult[0] == diceResult[1]);

        //dice porgo animacio
        callAnimateDice(hely1, diceResult[0]);
        callAnimateDice(hely2, diceResult[1]);

        //lassa a jatekos mit dobott
        hely1.sprite = diceSides[diceResult[0]-1];
        hely1.size = diceSpriteSize;

        hely2.sprite = diceSides[diceResult[1]-1];
        hely2.size = diceSpriteSize;

        if(ugynokDobas){
            ugynokDobasErtek = true;
            setLocked(false);
        }
             
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
                HelyszinKiBekapcs(false); //nem hasznalja fel ezert visszakapcsoljuk
            }

            adrenalinHasznalat.gameObject.SetActive(false);

            if (adrenalinMegerosites) {
                targyak.CallAdrenalinLoket();
                yield return new WaitUntil(() => ujertek.Count > 0);
                if(mehet){
                    Debug.Log("belep mehet");
                    Debug.Log("List: 0: " + ujertek[0] + " 1: " + ujertek[1]);
                    //EGYENLO ERTEKEK VIZSGALATA
                    //ha tul nagy vagy tul kicsi erteket ad meg az elso kockanak valtsa at az erteket
                    if(targyak.ujertek1 > 6 && diceResult[1] != 6 && targyak.ujertek2 != 6){ //ha tul nagy szamot adott meg legyen 6 az ertek
                        targyak.ujertek1 = 6;
                    }else if(targyak.ujertek1 > 6 && (diceResult[1] == 6 || targyak.ujertek2 == 6)){ //ha a masik ertek 6 akkor legyen az ertek 5
                        targyak.ujertek1 = 5;
                    }else if(targyak.ujertek1 < 1 && diceResult[1] != 1 && targyak.ujertek2 != 1){
                        targyak.ujertek1 = 1;
                    }else if(targyak.ujertek1 < 1 && (diceResult[1] == 1 || targyak.ujertek2 == 1)){
                        targyak.ujertek1 = 2;
                    }else if(targyak.ujertek1 == targyak.ujertek2 || targyak.ujertek1 == diceResult[1]){ //ha egyenlo a ket uj ertek vagy az elso egyenlo a mar meglevo masodik kockaval
                        if(targyak.ujertek1 == 1){
                            targyak.ujertek1++;
                        }else if(targyak.ujertek1 == 6){
                            targyak.ujertek1--;
                        }else{
                            targyak.ujertek1--;
                        }
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
                    }/*else if(targyak.ujertek1 == targyak.ujertek2 || targyak.ujertek2 == diceResult[0]){ //ha egyenlo a ket uj ertek vagy a masodik egyenlo a mar meglevo elso kockaval
                        if(targyak.ujertek2 == 1){
                            targyak.ujertek2++;
                        }else if(targyak.ujertek2 == 6){
                            targyak.ujertek2--;
                        }else{
                            targyak.ujertek2--;
                        }
                    }   */            

                    diceResult[0] = targyak.ujertek1;
                    diceResult[1] = targyak.ujertek2;
                    dobottEgyszer = true;

                    if(!ugynokDobas) //ha ugynok miatt van dobas ne vonjon le
                        ujradobasszamlalo++; //elhasznal egyet fent
                }        
            }
            //deaktivalas
            adrenalinMegerosites = false;
        }

        hely1.sprite = diceSides[diceResult[0]-1];
        hely1.size = diceSpriteSize;

        hely2.sprite = diceSides[diceResult[1]-1];
        hely2.size = diceSpriteSize;
        dobott++;

        //ha vegzett mindennel kapcsolja vissza az ertekvalasztast
        dice1btnBtn.enabled = true;
        dice2btnBtn.enabled = true;
        dice1btnBtn.interactable = true;
        dice2btnBtn.interactable = true;

        if(!ugynokDobas){ //ha ugynok miatt van dobas ne vonjon le
            ujradobasszamlalo--;
            Debug.Log("ujradobasszamlalo: " + ujradobasszamlalo);
            if(ujradobasszamlalo == 0){
                dobottEgyszer = true;
            } 
        } 
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

    public void callAnimateDice(SpriteRenderer rend, int diceErtek) => StartCoroutine(AnimateTheDice(rend, diceErtek));
    private IEnumerator AnimateTheDice(SpriteRenderer rend, int diceErtek)
    {
        int randomDiceSide;
        float time = 0f;
        bool fusson = true;

        while(fusson){
            time += Time.time;
            //Debug.Log("time: " + time);

            if(time >= 200f) fusson = false;

            randomDiceSide = Random.Range(0, 5);

            rend.sprite = diceSides[Random.Range(0, 5)];
            rend.size = diceSpriteSize;

            yield return new WaitForSeconds(0.05f);
        }

        rend.sprite = diceSides[diceErtek - 1];
        rend.size = diceSpriteSize;
    }
}
