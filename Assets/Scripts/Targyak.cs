using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Targyak : MonoBehaviour
{
    private Akciok akciok;
    private Elet elet;
    private Akciopont akciopont;
    private movement movement;
    private Energia energia;
    private Ugynok ugynok;
    private Dice dice;
    private jatekmanager jatekmanager;
    public TMP_InputField kocka1ertek;
    public TMP_InputField kocka2ertek;
    public int ujertek1;
    public int ujertek2;
    public int targy_szamlalo = 0;
    public int adrenalinloket = 0;
    public int hackercsatlakozo = 0;
    public int lathatatlanoltozet = 0;
    public int droidgepagyu = 0;
    public int matavtaviranyito = 0;
    public int fustgranat = 0;

    [SerializeField] private bool vanUgynok = false;

    public bool lathatatlanOltozetAktivalva = false;
    public bool matavtaviranyitoAktivalva = false;
    private int randomszam;
    public Button confirmNewValue;
    public Button cancelNewValue;

    //targy megszerezve ui
    public TMP_Text adrenalinMegszerezve;
    public TMP_Text hackerMegszerezve;
    public TMP_Text lathatatlanMegszerezve;
    public TMP_Text droidMegszerezve;
    public TMP_Text matavMegszerezve;
    public TMP_Text alomhozoMegszerezve;

    //targy felhasznalva ui
    public TMP_Text adrenalinFelhasznalva;
    public TMP_Text hackerFelhasznalva;
    public TMP_Text lathatatlanFelhasznalva;
    public TMP_Text droidFelhasznalva;
    public TMP_Text matavFelhasznalva;
    public TMP_Text alomhozoFelhasznalva;

    public List<string> elerheto_targyak = new List<string>{"Adrenalinloket", "Hacker csatlakozo", "Lathatatlan oltozet", "Droid agyu", "Matav taviranyito", "Alomhozo fustgranat"};

    private void Awake() {
        akciok = FindObjectOfType<Akciok>(); 
        elet = FindObjectOfType<Elet>();
        akciopont = FindObjectOfType<Akciopont>();
        movement = FindObjectOfType<movement>();
        energia = FindObjectOfType<Energia>();
        ugynok = FindObjectOfType<Ugynok>();
        dice = FindObjectOfType<Dice>();
        jatekmanager = FindObjectOfType<jatekmanager>();
    }

    private void Start() {
        adrenalinFelhasznalva.gameObject.SetActive(false);
        hackerFelhasznalva.gameObject.SetActive(false);
        lathatatlanFelhasznalva.gameObject.SetActive(false);
        droidFelhasznalva.gameObject.SetActive(false);
        matavFelhasznalva.gameObject.SetActive(false);
        alomhozoFelhasznalva.gameObject.SetActive(false);
    }

    public void RandomTargy()
    {
        if(elerheto_targyak.Count == 0) return;

            randomszam = UnityEngine.Random.Range(0, elerheto_targyak.Count);

        //megszerezve ui es beaddolas
        if(elerheto_targyak[randomszam].Equals("Adrenalinloket")){
            adrenalinMegszerezve.text = "X";
            adrenalinloket++;
            adrenalinFelhasznalva.gameObject.SetActive(true);
            Debug.Log("Kaptal egy AdrenalinLoketet!");
        }else if(elerheto_targyak[randomszam].Equals("Hacker csatlakozo")){
            hackerMegszerezve.text = "X";
            hackercsatlakozo++;
            hackerFelhasznalva.gameObject.SetActive(true);
            Debug.Log("Kaptal egy Hacker Csatlakozot!");
        }else if(elerheto_targyak[randomszam].Equals("Lathatatlan oltozet")){
            lathatatlanMegszerezve.text = "X";
            lathatatlanoltozet++;
            lathatatlanFelhasznalva.gameObject.SetActive(true);
            Debug.Log("Kaptal egy Lathatatlan oltozetet!");
        }else if(elerheto_targyak[randomszam].Equals("Droid agyu")){
            droidMegszerezve.text = "X";
            droidgepagyu++;
            droidFelhasznalva.gameObject.SetActive(true);
            Debug.Log("Kaptal egy Droid-X2 Gepagyut!");
        }else if(elerheto_targyak[randomszam].Equals("Matav taviranyito")){
            matavMegszerezve.text = "X";
            matavtaviranyito++;
            matavFelhasznalva.gameObject.SetActive(true);
            Debug.Log("Kaptal egy Matav Taviranyitot!");
        }else if(elerheto_targyak[randomszam].Equals("Alomhozo fustgranat")){
            alomhozoMegszerezve.text = "X";
            fustgranat++;
            alomhozoFelhasznalva.gameObject.SetActive(true);
            Debug.Log("Kaptal egy Alomhozo Fustgranatot!");
        }

        elerheto_targyak.RemoveAt(randomszam); //szedje ki a listabol
    }

    public void addAdrenalin() {
        adrenalinloket = 1;
    }

    private void Update() {     
        //betu kitorlese 
        if(!kocka1ertek.text.Equals("")){ //megnezzuk hogy van e mar valami a szovegben
            for(int i = 0; i < kocka1ertek.text.Length; i++) //vegig megyunk a szovegen
            {              
                if(!Char.IsDigit(kocka1ertek.text[i])){ //ha a betu nem szam torolje
                    Debug.Log("updaate");
                    kocka1ertek.text = kocka1ertek.text.Remove(i);
                }
            }
        }

        if(!kocka2ertek.text.Equals("")){ //megnezzuk hogy van e mar valami a szovegben
            for(int i = 0; i < kocka2ertek.text.Length; i++) //vegig megyunk a szovegen
            {
                if(!Char.IsDigit(kocka2ertek.text[i])){ //ha a betu nem szam torolje
                    kocka2ertek.text = kocka2ertek.text.Remove(i);
                }
            }
        }
    }

    public void CallAdrenalinLoket() => StartCoroutine(AdrenalinLoket());

    public IEnumerator AdrenalinLoket() {
        Debug.Log("adrenalin ienumerator");

        kocka1ertek.text = dice.getDices()[0].ToString(); //maradjon uresen es jelenjen meg kepen a kocka ertekek, hogy while-al varakoztatni lehessen?
        kocka2ertek.text = dice.getDices()[1].ToString();

        kocka1ertek.gameObject.SetActive(true); //aktivalja az input mezot hogy meg lehessen adni az uj erteket
        kocka2ertek.gameObject.SetActive(true);  

        confirmNewValue.gameObject.SetActive(true);//aktivalja a gombot hozza
        cancelNewValue.gameObject.SetActive(true);

        //VARNIA KELL A GOMBRA || itt folytatja
        var waitForButton = new WaitForUIButtons(confirmNewValue, cancelNewValue);
        yield return waitForButton.Reset();

        //nem szam karakter levedes?
        ujertek1 = int.Parse(kocka1ertek.text);
        ujertek2 = int.Parse(kocka2ertek.text); //hogy tunik el az elozo? || egymas melle kerul a ket input vagy gomb ami deaktivalja a inputot
        
        Debug.Log("ujertek1: " + ujertek1 + " ujertek2: " + ujertek2);

        if(waitForButton.PressedButton == confirmNewValue){
            deactivateInputOk(true);
            dice.ujertek.Add(ujertek1); //csak akkor adja at ha leokezta
            dice.ujertek.Add(ujertek2); //uj adat amit a user adott meg
            dice.mehet = true;
            dice.HelyszinKiBekapcs(false);
            adrenalinFelhasznalva.text = "X";
            yield break; //kilepeshez
        }else{
            deactivateInputOk(false);
            dice.HelyszinKiBekapcs(false);
        }  

        //ha nem lepett ki eddig
        //dice.ujertek[0] = dice.getDices()[0]; 
        //dice.ujertek[1] = dice.getDices()[1]; //regi adat, hogy ne legyen hibas       
    }

    public void deactivateInputOk(bool targyelvesztes) {
        kocka1ertek.gameObject.SetActive(false);
        kocka2ertek.gameObject.SetActive(false);
        confirmNewValue.gameObject.SetActive(false);//deaktivalja a gombot hozza
        cancelNewValue.gameObject.SetActive(false);
        if(targyelvesztes)
            adrenalinloket = 0; //targy elvesztese
    }

    public void HackerCsatlakozo() { //kesz
        //+2 tolteny
        akciok.Betarazas(2);
        akciopont.UpdateAkciopont(1); //betarazas miatt egy pont visszaadasa
        //+1 elet
        elet.Eletplusz();
        //+1 akcio
        akciopont.UpdateAkciopont(1);

        hackercsatlakozo = 0; //targy elvesztese 

        Debug.Log("hacker felhasznalva");

        //felhasznalva ui
        hackerFelhasznalva.text = "X";     
    }

    public void LathatatlanOltozek() { //kesz
        lathatatlanOltozetAktivalva = true;
        lathatatlanoltozet = 0; //targy elvesztese 

        Debug.Log("lathatatlan felhasznalva");

        //felhasznalva ui
        lathatatlanFelhasznalva.text = "X";  
    }

    public void DroidGepagyu() { 
        //deaktivalni minden objectet kiveve a ugynok text boxokat es addig nem vissza aktivalni amig nem kattintott ra valamelyikre      
        
        //deaktivalas
        //jatekmanager.ugynokDeaktivalas(false);

        vanUgynok = false;

        //nezze meg hogy van ugynokcsapat valahol kulonben ne aktivalja
        foreach(var item in ugynok.oneone){
            if(item.Equals("1") || item.Equals("2") || item.Equals("3") || item.Equals("4") || item.Equals("5") || item.Equals("6")) vanUgynok = true;
        }
        foreach(var item in ugynok.onetwo){
            if(item.Equals("1") || item.Equals("2") || item.Equals("3") || item.Equals("4") || item.Equals("5") || item.Equals("6")) vanUgynok = true;
        }
        foreach(var item in ugynok.onethree){
            if(item.Equals("1") || item.Equals("2") || item.Equals("3") || item.Equals("4") || item.Equals("5") || item.Equals("6")) vanUgynok = true;
        }
        foreach(var item in ugynok.onefour){
            if(item.Equals("1") || item.Equals("2") || item.Equals("3") || item.Equals("4") || item.Equals("5") || item.Equals("6")) vanUgynok = true;
        }
        foreach(var item in ugynok.twoone){
            if(item.Equals("1") || item.Equals("2") || item.Equals("3") || item.Equals("4") || item.Equals("5") || item.Equals("6")) vanUgynok = true;
        }
        foreach(var item in ugynok.twotwo){
            if(item.Equals("1") || item.Equals("2") || item.Equals("3") || item.Equals("4") || item.Equals("5") || item.Equals("6")) vanUgynok = true;
        }
        foreach(var item in ugynok.twothree){
            if(item.Equals("1") || item.Equals("2") || item.Equals("3") || item.Equals("4") || item.Equals("5") || item.Equals("6")) vanUgynok = true;
        }
        foreach(var item in ugynok.twofour){
            if(item.Equals("1") || item.Equals("2") || item.Equals("3") || item.Equals("4") || item.Equals("5") || item.Equals("6")) vanUgynok = true;
        }
        foreach(var item in ugynok.threeone){
            if(item.Equals("1") || item.Equals("2") || item.Equals("3") || item.Equals("4") || item.Equals("5") || item.Equals("6")) vanUgynok = true;
        }
        foreach(var item in ugynok.threetwo){
            if(item.Equals("1") || item.Equals("2") || item.Equals("3") || item.Equals("4") || item.Equals("5") || item.Equals("6")) vanUgynok = true;
        }
        foreach(var item in ugynok.threethree){
            if(item.Equals("1") || item.Equals("2") || item.Equals("3") || item.Equals("4") || item.Equals("5") || item.Equals("6")) vanUgynok = true;
        }
        foreach(var item in ugynok.threefour){
            if(item.Equals("1") || item.Equals("2") || item.Equals("3") || item.Equals("4") || item.Equals("5") || item.Equals("6")) vanUgynok = true;
        }

        if(!vanUgynok){
            Debug.Log("nincs sehol ugynok csapat");
            return; //ha nincs sehol ugynok ne fussok le
        } 

        jatekmanager.UpdateGameState(jatekmanager.GameState.Ugynok); //ugynok state (minden kikapcsolva);
        
        ugynok.droidagyuAktivalva = true;

        Debug.Log("kattints egy ugynok csapatra!");

        droidgepagyu = 0; //targy elvesztese

        Debug.Log("droid felhasznalva");

        //felhasznalva ui
        droidFelhasznalva.text = "X";
    }

    public void MatavTaviranyito() {
        matavtaviranyitoAktivalva = true;
        matavtaviranyito = 0; //targy elvesztese

        Debug.Log("matav felhasznalva");

        //felhasznalva ui
        matavFelhasznalva.text = "X";
    }

    public void FustGranat() {
        energia.granatAktivalva = true;
        fustgranat = 0; //targy elvesztese   

        Debug.Log("granat felhasznalva");

        //felhasznalva ui
        alomhozoFelhasznalva.text = "X";   
    }
}