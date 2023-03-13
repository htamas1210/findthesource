using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using TMPro;

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

    private int[] helyszinAktivalasSzamlalo;

    //textboxos az aktivalas szamlalohoz
    public List<TMP_Text> oneoneText; //2
    public TMP_Text onetwoText; //1
    public List<TMP_Text> onethreeText; //2
    public List<TMP_Text> onefourText; //2
    public TMP_Text twooneText;
    public List<TMP_Text> twotwoText;
    public TMP_Text twothreeText;
    public TMP_Text twofourText;

    public TMP_Text threeoneText;
    public List<TMP_Text> threetwoText;
    public TMP_Text threethreeText;
    public List<TMP_Text> threefourText;


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

        helyszinAktivalasSzamlalo = new int[12];
        for (int i = 0; i < helyszinAktivalasSzamlalo.Length; i++){
            helyszinAktivalasSzamlalo[i] = 0;
        }
    }

    public void HelyszinAktivalas()
    {
        //1-es mez� kesz
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 1)
        {
            if(helyszinAktivalasSzamlalo[0] == 2) return; //ketszer lehet aktivalni
            //ugynokcsapat oles barhol tolteny nelkul
            //ugynok.canKill = true; //megolhetunk egy csapatot (nem jo) || mint a targy aktivalas

            if(!targyak.matavtaviranyitoAktivalva){
                akciopont.UpdateAkciopont(-1);
                energia.csokkenEnergia(1);
            }
    
            helyszinAktivalasSzamlalo[0]++; 

        }
        //2-es mez� -- K�SZ
        if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 1)
        {
            if(helyszinAktivalasSzamlalo[1] == 1) return; //egyszer lehet aktivalni

            upgrade.canUpgrade = true;

            if(!targyak.matavtaviranyitoAktivalva){
                //akciopont.akciopont++;
                akciopont.UpdateAkciopont(1);
                energia.csokkenEnergia(2);
            }

            helyszinAktivalasSzamlalo[1]++;
        }
        //3-es mez� 
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 1)
        {
            if(helyszinAktivalasSzamlalo[2] == 1) return; //egyszer lehet aktivalni

            movement.helyreTeleport(); //hogy teleportal (jo?)
            if(!targyak.matavtaviranyitoAktivalva){
                energia.csokkenEnergia(1);
            }

            helyszinAktivalasSzamlalo[2]++;
        }
        //4-es mez� kesz
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 2)
        {
            if(helyszinAktivalasSzamlalo[3] == 1) return; //egyszer lehet aktivalni

            //kapsz egy t�rgyat
            targyak.RandomTargy();
            targyak.targy_szamlalo++;
            if(!targyak.matavtaviranyitoAktivalva){
                akciopont.UpdateAkciopont(-1);
                energia.csokkenEnergia(1);
            }

            helyszinAktivalasSzamlalo[3]++;
        }
        //5-es mez� kesz
        if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 2)
        {
            if(helyszinAktivalasSzamlalo[4] == 2) return; //ketszer lehet aktivalni

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

            helyszinAktivalasSzamlalo[4]++;
        }
        //6-es mez� kesz
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 2)
        {
            if(helyszinAktivalasSzamlalo[5] == 2) return; //ketszer lehet aktivalni

            //+1 akcio
            akciopont.UpdateAkciopont(1);

            helyszinAktivalasSzamlalo[5]++;
        }
        //7-es mez� -- K�SZ
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 3)
        {
            if(helyszinAktivalasSzamlalo[6] == 2) return; //ketszer lehet aktivalni

            //1 fejleszt�s ingyen
            upgrade.canUpgrade = true;
            if(!targyak.matavtaviranyitoAktivalva){
                akciopont.UpdateAkciopont(-2);
            }

            helyszinAktivalasSzamlalo[6]++;
        }
        //8-es mez� kesz
        if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 3)
        {
            if(helyszinAktivalasSzamlalo[7] == 1) return; //egyszer lehet aktivalni
            
            //2 kocka dobas egyik +ap masik -energia
            int eredmeny1 = UnityEngine.Random.Range(1,7); //+ap
            int eredmeny2 = UnityEngine.Random.Range(1,7); //-energia
            Debug.Log("Dobas eredmeny elso: "+eredmeny1+ " masodik: " + eredmeny2);
            akciopont.UpdateAkciopont(eredmeny1);
            energia.csokkenEnergia(eredmeny2);

            helyszinAktivalasSzamlalo[7]++;
        }
        //9-es mez� -- K�SZ
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 3)
        {
            if(helyszinAktivalasSzamlalo[8] == 1) return; //egyszer lehet aktivalni

            targyak.RandomTargy();
            targyak.targy_szamlalo++;
            if(!targyak.matavtaviranyitoAktivalva){
                akciopont.UpdateAkciopont(-2);
            }

            helyszinAktivalasSzamlalo[8]++;
        }
        //10-es mez� -- K�SZ ?
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 4)
        {
            if(helyszinAktivalasSzamlalo[9] == 2) return; //ketszer lehet aktivalni

            //+4 t�lt�ny
            akciok.Betarazas(4); //ha nincs negy darab tolteny toltse be a maradekot vagy ne lehessen aktivalni a helyszint?
            if(!targyak.matavtaviranyitoAktivalva){
                akciopont.UpdateAkciopont(-1);
            }

            helyszinAktivalasSzamlalo[9]++;
        }
        //11-es mez� kesz
        if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 4)
        {
            if(helyszinAktivalasSzamlalo[10] == 1) return; //egyszer lehet aktivalni

            //Dobj! Megkapod a t�rgyat.
            targyak.RandomTargy();
            targyak.targy_szamlalo++;
            if(!targyak.matavtaviranyitoAktivalva){
                energia.csokkenEnergia(1);
            }

            helyszinAktivalasSzamlalo[10]++;
        }
        //12-es mez�  -- K�SZ
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 4)
        {
            if(helyszinAktivalasSzamlalo[11] == 2) return; //ketszer lehet aktivalni

            //+1 elet
            elet.Eletplusz();
            if(!targyak.matavtaviranyitoAktivalva){
                akciopont.UpdateAkciopont(-1);
            }

            helyszinAktivalasSzamlalo[11]++;
        }
    }
}
