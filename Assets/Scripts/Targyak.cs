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

    public int targy_szamlalo = 0;
    public int adrenalinloket = 0;
    public int hackercsatlakozo = 0;
    public int lathatatlanoltozet = 0;
    public int droidgepagyu = 0;
    public int matavtaviranyito = 0;
    public int fustgranat = 0;

    private void Start() {
        akciok = FindObjectOfType<Akciok>(); 
        elet = FindObjectOfType<Elet>();
        akciopont = FindObjectOfType<Akciopont>();
        movement = FindObjectOfType<movement>();
        energia = FindObjectOfType<Energia>();
    }

    public void RandomTargy()
    {
        int randomszam = UnityEngine.Random.Range(0, 5);
        if (randomszam == 0)
        {
            adrenalinloket++;
            Debug.Log("Kapt�l egy AdrenalinL�ketet!");
        }
        else if (randomszam == 1)
        {
            hackercsatlakozo++;
            Debug.Log("Kapt�l egy Hacker Csatlakoz�t!");
        }
        else if (randomszam == 2)
        {
            lathatatlanoltozet++;
            Debug.Log("Kapt�l egy L�thatatlan �lt�zetet!");
        }
        else if (randomszam == 3)
        {
            droidgepagyu++;
            Debug.Log("Kapt�l egy Droid-X2 G�p�gy�t!");
        }
        else if (randomszam == 4)
        {
            matavtaviranyito++;
            Debug.Log("Kapt�l egy Mata'v T�vir�ny�t�t!");
        }
        else if (randomszam == 5)
        {
            fustgranat++;
            Debug.Log("Kapt�l egy �lomhoz� F�stgr�n�tot!");
        }
    }

    public void AdrenalinLoket() {
        targy_szamlalo++;
    }

    public void HackerCsatlakozo() { //Hogyan kell aktivalni?
        //+2 tolteny
        akciok.Betarazas(2);
        //+1 elet
        elet.Eletplusz();
        //+1 akcio
        akciopont.akciopont++;
        targy_szamlalo++;
    }

    public void LathatatlanOltozek() {
        movement.mozgasHelyre(2, 2); //megadni inkabb a hely nevet ahova menni akar? | input field es nev megadas
        targy_szamlalo++;
    }

    public void DroidGepagyu() {
        targy_szamlalo++;
    }

    public void MatavTaviranyito() {
        targy_szamlalo++;
    }

    public void FustGranat() {
        energia.granatAktivalva = true;
        targy_szamlalo++;
    }

}
