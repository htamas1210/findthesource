using System.Collections;
using System.Collections.Generic;
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
    public bool lathatatlanOltozetAktivalva = false;
    public bool matavtaviranyitoAktivalva = false;
    private int randomszam;

    public Button confirmNewValue;
    public Button cancelNewValue;


    private void Start() {
        akciok = FindObjectOfType<Akciok>(); 
        elet = FindObjectOfType<Elet>();
        akciopont = FindObjectOfType<Akciopont>();
        movement = FindObjectOfType<movement>();
        energia = FindObjectOfType<Energia>();
        ugynok = FindObjectOfType<Ugynok>();
        dice = FindObjectOfType<Dice>();
    }

    public void RandomTargy()
    {
        string[] elerheto_targyak = {"Adrenalinloket", "Hacker csatlakozo", "Lathatatlan oltozet", "Droid agyu", "Matav taviranyito", "Alomhozo fustgranat"} ;
        
        do{
            randomszam = UnityEngine.Random.Range(0, elerheto_targyak.Length);
        }while(!elerheto_targyak[randomszam].Equals(""));


        elerheto_targyak[randomszam] = "";

        if (randomszam == 0)
        {
            adrenalinloket++;
            Debug.Log("Kaptal egy AdrenalinLoketet!");
        }
        else if (randomszam == 1)
        {
            hackercsatlakozo++;
            Debug.Log("Kaptal egy Hacker Csatlakozot!");
        }
        else if (randomszam == 2)
        {
            lathatatlanoltozet++;
            Debug.Log("Kaptal egy Lathatatlan oltozetet!");
        }
        else if (randomszam == 3)
        {
            droidgepagyu++;
            Debug.Log("Kaptal egy Droid-X2 Gepagyut!");
        }
        else if (randomszam == 4)
        {
            matavtaviranyito++;
            Debug.Log("Kaptal egy Matav Taviranyitot!");
        }
        else if (randomszam == 5)
        {
            fustgranat++;
            Debug.Log("Kaptal egy Alomhozo Fustgranatot!");
        }
    }

    public void addAdrenalin() {
        adrenalinloket = 1;
    }

    public void CallAdrenalinLoket() => StartCoroutine(AdrenalinLoket());

    public IEnumerator AdrenalinLoket() {
        Debug.Log("nefefs");
        kocka1ertek.text = dice.getDices()[0].ToString(); //maradjon uresen es jelenjen meg kepen a kocka ertekek, hogy while-al varakoztatni lehessen?
        kocka2ertek.text = dice.getDices()[1].ToString();

        kocka1ertek.gameObject.SetActive(true); //aktivalja az input mezot hogy meg lehessen adni az uj erteket
        kocka2ertek.gameObject.SetActive(true);  

        confirmNewValue.gameObject.SetActive(true);//aktivalja a gombot hozza
        cancelNewValue.gameObject.SetActive(true);

        //VARNIA KELL A GOMBRA || itt folytatja
        var waitForButton = new WaitForUIButtons(confirmNewValue, cancelNewValue);
        yield return waitForButton.Reset();

        ujertek1 = int.Parse(kocka1ertek.text);
        ujertek2 = int.Parse(kocka2ertek.text); //hogy tunik el az elozo? || egymas melle kerul a ket input vagy gomb ami deaktivalja a inputot
        
        if(waitForButton.PressedButton == confirmNewValue){
            deactivateInputOk(true);
            //dice.ujertek[0] = ujertek1; //csak akkor adja at ha leokezta
            //dice.ujertek[1] = ujertek2; //uj adat amit a user adott meg
            dice.mehet = true;
            dice.HelyszinKiBekapcs(false);
            yield break; //kilepeshez
        }else{
            deactivateInputOk(false);
        }  

        //ha nem lepett ki eddig
        dice.ujertek[0] = dice.getDices()[0]; 
        dice.ujertek[1] = dice.getDices()[1]; //regi adat, hogy ne legyen hibas       
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
        //+1 elet
        elet.Eletplusz();
        //+1 akcio
        akciopont.akciopont++;
        
    }

    public void LathatatlanOltozek() { //kesz
        //movement.mozgasHelyre(2, 2); //megadni inkabb a hely nevet ahova menni akar? | input field es nev megadas
        lathatatlanOltozetAktivalva = true;
        
    }

    public void DroidGepagyu() { //kesz
        
        //ugynok cucc
        ugynok.canKill = true; //barhol meg tud olni ha kattint
    }

    public void MatavTaviranyito() {
        matavtaviranyitoAktivalva = true;
    }

    public void FustGranat() {
        energia.granatAktivalva = true;
        
    }

}
