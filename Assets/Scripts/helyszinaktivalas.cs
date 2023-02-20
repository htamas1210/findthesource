using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class helyszinaktivalas : MonoBehaviour
{
    private Elet elet;
    private Akciok akciok;
    private Targyak targyak;
    private Upgrade upgrade;
    private Akciopont akciopont;
    private movement movement;
    private Ugynok ugynok;
    private Energia energia;

    private void Awake()
    {
        akciopont = FindObjectOfType<Akciopont>();
        movement = FindObjectOfType<movement>();
        upgrade = FindObjectOfType<Upgrade>();
        targyak = FindObjectOfType<Targyak>();
        akciok = FindObjectOfType<Akciok>();
        elet = FindObjectOfType<Elet>();
        ugynok = FindObjectOfType<Ugynok>();
        energia = FindObjectOfType<Energia>();
    }

    public void HelyszinAktivalas()
    {
        //1-es mez� kesz
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 1)
        {
            //ugynokcsapat oles barhol tolteny nelkul
            ugynok.canKill = true; //megolhetunk egy csapatot
            if(!targyak.matavtaviranyitoAktivalva){
                akciopont.UpdateAkciopont(-1);
                energia.csokkenEnergia(1);
            }

        }
        //2-es mez� -- K�SZ
        if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 1)
        {
            upgrade.canUpgrade = true;
            if(!targyak.matavtaviranyitoAktivalva){
                //akciopont.akciopont++;
                akciopont.UpdateAkciopont(1);
                energia.csokkenEnergia(2);
            }
        }
        //3-es mez� 
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 1)
        {
            movement.helyreTeleport(); //hogy teleportal
            if(!targyak.matavtaviranyitoAktivalva){
                energia.csokkenEnergia(1);
            }
        }
        //4-es mez� kesz
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 2)
        {
            //kapsz egy t�rgyat
            targyak.RandomTargy();
            targyak.targy_szamlalo++;
            if(!targyak.matavtaviranyitoAktivalva){
                akciopont.UpdateAkciopont(-1);
                energia.csokkenEnergia(1);
            }
        }
        //5-es mez� kesz
        if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 2)
        {
            ///dobj paros +3 ap paratlan -1 energia
            int eredmeny = UnityEngine.Random.Range(1,7);
            Debug.Log("Dobas eredmeny: " + eredmeny);
            if(eredmeny % 2 == 0)
                akciopont.UpdateAkciopont(3); //+3ap
            else
                energia.csokkenEnergia(1);

            if(!targyak.matavtaviranyitoAktivalva){
                akciopont.UpdateAkciopont(-1);
            }
        }
        //6-es mez� kesz
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 2)
        {
            //+1 akcio
            akciopont.UpdateAkciopont(1);
        }
        //7-es mez� -- K�SZ
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 3)
        {
            //1 fejleszt�s ingyen
            upgrade.canUpgrade = true;
            if(!targyak.matavtaviranyitoAktivalva){
                akciopont.UpdateAkciopont(-2);
            }
        }
        //8-es mez� kesz
        if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 3)
        {

            //2 kocka dobas egyik +ap masik -energia
            int eredmeny1 = UnityEngine.Random.Range(1,7); //+ap
            int eredmeny2 = UnityEngine.Random.Range(1,7); //-energia
            Debug.Log("Dobas eredmeny elso: "+eredmeny1+ " masodik: " + eredmeny2);
            akciopont.UpdateAkciopont(eredmeny1);
            energia.csokkenEnergia(eredmeny2);
        }
        //9-es mez� -- K�SZ
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 3)
        {
            targyak.RandomTargy();
            targyak.targy_szamlalo++;
            if(!targyak.matavtaviranyitoAktivalva){
                akciopont.UpdateAkciopont(-2);
            }
        }
        //10-es mez� -- K�SZ ?
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 4)
        {
            //+4 t�lt�ny
            akciok.Betarazas(4); //ha nincs negy darab tolteny toltse be a maradekot vagy ne lehessen aktivalni a helyszint?
            if(!targyak.matavtaviranyitoAktivalva){
                akciopont.UpdateAkciopont(-1);
            }
        }
        //11-es mez� kesz
        if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 4)
        {
            //Dobj! Megkapod a t�rgyat.
            targyak.RandomTargy();
            targyak.targy_szamlalo++;
            if(!targyak.matavtaviranyitoAktivalva){
                energia.csokkenEnergia(1);
            }
        }
        //12-es mez�  -- K�SZ
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 4)
        {
            //+1 elet
            elet.Eletplusz();
            if(!targyak.matavtaviranyitoAktivalva){
                akciopont.UpdateAkciopont(-1);
            }
        }
    }
}
