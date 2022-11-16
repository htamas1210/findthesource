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

    private void Start() {
        akciok = FindObjectOfType<Akciok>(); 
        elet = FindObjectOfType<Elet>();
        akciopont = FindObjectOfType<Akciopont>();
        movement = FindObjectOfType<movement>();
        energia = FindObjectOfType<Energia>();
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