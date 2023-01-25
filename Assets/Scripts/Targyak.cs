using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targyak : MonoBehaviour
{
    private Akciok akciok;
    private Elet elet;
    private Akciopont akciopont;
    private movement movement;
    private Energia energia;
    private Ugynok ugynok;

    public GameObject kocka1ertek;
    public GameObject kocka2ertek;
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

    private void Start() {
        akciok = FindObjectOfType<Akciok>(); 
        elet = FindObjectOfType<Elet>();
        akciopont = FindObjectOfType<Akciopont>();
        movement = FindObjectOfType<movement>();
        energia = FindObjectOfType<Energia>();
        ugynok = FindObjectOfType<Ugynok>();
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

    public void AdrenalinLoket() {
        kocka1ertek.SetActive(true); //aktivalja az input mezot hogy meg lehessen adni az uj erteket
        kocka2ertek.SetActive(true);
        ujertek1 = int.Parse(kocka1ertek.text);
        ujertek2 = int.Parse(kocka2ertek.text);
        //uj ertek atadasa a dicenak

        //input mezo deaktivalas
        kocka1ertek.SetActive(false);
        kocka2ertek.SetActive(false);
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
