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

    public int targy_szamlalo = 0;
    public int adrenalinloket = 0;
    public int hackercsatlakozo = 0;
    public int lathatatlanoltozet = 0;
    public int droidgepagyu = 0;
    public int matavtaviranyito = 0;
    public int fustgranat = 0;
    public bool lathatatlanOltozetAktivalva = false;

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
        int randomszam = UnityEngine.Random.Range(0, 5);
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
        targy_szamlalo++;
    }

    public void HackerCsatlakozo() {
        //+2 tolteny
        akciok.Betarazas(2);
        //+1 elet
        elet.Eletplusz();
        //+1 akcio
        akciopont.akciopont++;
        targy_szamlalo++;
    }

    public void LathatatlanOltozek() {
        //movement.mozgasHelyre(2, 2); //megadni inkabb a hely nevet ahova menni akar? | input field es nev megadas
        lathatatlanOltozetAktivalva = true;
        targy_szamlalo++;
    }

    public void DroidGepagyu() {
        targy_szamlalo++;
        //ugynok cucc
        ugynok.canKill = true; //barhol meg tud olni ha kattint
    }

    public void MatavTaviranyito() {
        targy_szamlalo++;
    }

    public void FustGranat() {
        energia.granatAktivalva = true;
        targy_szamlalo++;
    }

}
