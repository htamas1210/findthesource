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
    private jatekmanager jatekmanager;

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
        //1-es mezo
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 1)
        {
            if(helyszinAktivalasSzamlalo[0] == 2) return; //ketszer lehet aktivalni
            //ugynokcsapat oles barhol tolteny nelkul
            targyak.DroidGepagyu();

            if(!targyak.matavtaviranyitoAktivalva){
                akciopont.UpdateAkciopont(-1);
                energia.csokkenEnergia(1);
            }
    
            oneoneText[helyszinAktivalasSzamlalo[0]].text = "X";
            helyszinAktivalasSzamlalo[0]++; 
        }
        //2-es mezo
        if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 1)
        {
            if(helyszinAktivalasSzamlalo[1] == 1) return; //egyszer lehet aktivalni

            upgrade.canUpgrade = true;
            jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.Fejlesztes);
            if(!targyak.matavtaviranyitoAktivalva){
                //akciopont.akciopont++;
                akciopont.UpdateAkciopont(1);
                energia.csokkenEnergia(2);
            }

            twooneText.text = "X";
            helyszinAktivalasSzamlalo[1]++;
        }
        //3-es mezo
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 1)
        {
            if(helyszinAktivalasSzamlalo[2] == 1) return; //egyszer lehet aktivalni

            //movement.helyreTeleport(); //hogy teleportal (jo?)
            targyak.lathatatlanOltozetAktivalva = true; //mint a targy
            if(!targyak.matavtaviranyitoAktivalva){
                energia.csokkenEnergia(1);
            }

            threeoneText.text = "X";
            helyszinAktivalasSzamlalo[2]++;
        }
        //4-es mezo
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 2)
        {
            if(helyszinAktivalasSzamlalo[3] == 1) return; //egyszer lehet aktivalni

            //kapsz egy targyat
            targyak.RandomTargy();
            targyak.targy_szamlalo++;
            if(!targyak.matavtaviranyitoAktivalva){
                akciopont.UpdateAkciopont(-1);
                energia.csokkenEnergia(1);
            }

            onetwoText.text = "X";
            helyszinAktivalasSzamlalo[3]++;
        }
        //5-es mezo
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

            twotwoText[helyszinAktivalasSzamlalo[4]].text = "X";
            helyszinAktivalasSzamlalo[4]++;
        }
        //6-es mezo
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 2)
        {
            if(helyszinAktivalasSzamlalo[5] == 2) return; //ketszer lehet aktivalni

            //+1 akcio
            akciopont.UpdateAkciopont(1);

            threetwoText[helyszinAktivalasSzamlalo[5]].text = "X";
            helyszinAktivalasSzamlalo[5]++;
        }
        //7-es mezo
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 3)
        {
            if(helyszinAktivalasSzamlalo[6] == 2) return; //ketszer lehet aktivalni

            //1 fejlesztes ingyen
            upgrade.canUpgrade = true;
            jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.Fejlesztes);
            if(!targyak.matavtaviranyitoAktivalva){
                akciopont.UpdateAkciopont(-2);
            }

            onethreeText[helyszinAktivalasSzamlalo[6]].text = "X";
            helyszinAktivalasSzamlalo[6]++;
        }
        //8-es mezo
        if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 3)
        {
            if(helyszinAktivalasSzamlalo[7] == 1) return; //egyszer lehet aktivalni
            
            //2 kocka dobas egyik +ap masik -energia
            int eredmeny1 = UnityEngine.Random.Range(1,7); //+ap
            int eredmeny2 = UnityEngine.Random.Range(1,7); //-energia
            Debug.Log("Dobas eredmeny elso: "+eredmeny1+ " masodik: " + eredmeny2);
            akciopont.UpdateAkciopont(eredmeny1);
            energia.csokkenEnergia(eredmeny2);

            twothreeText.text = "X";
            helyszinAktivalasSzamlalo[7]++;
        }
        //9-es mezo
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 3)
        {
            if(helyszinAktivalasSzamlalo[8] == 1) return; //egyszer lehet aktivalni

            targyak.RandomTargy();
            targyak.targy_szamlalo++;
            if(!targyak.matavtaviranyitoAktivalva){
                akciopont.UpdateAkciopont(-2);
            }

            threethreeText.text = "X";
            helyszinAktivalasSzamlalo[8]++;
        }
        //10-es mezo
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 4)
        {
            if(helyszinAktivalasSzamlalo[9] == 2) return; //ketszer lehet aktivalni

            //+4 tolteny
            akciok.Betarazas(4); //ha nincs negy darab tolteny toltse be a maradekot vagy ne lehessen aktivalni a helyszint?
            if(!targyak.matavtaviranyitoAktivalva){
                akciopont.UpdateAkciopont(0); //betarazasba levon egyet (csak placeholder)
            }

            onefourText[helyszinAktivalasSzamlalo[9]].text = "X";
            helyszinAktivalasSzamlalo[9]++;
        }
        //11-es mezo
        if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 4)
        {
            if(helyszinAktivalasSzamlalo[10] == 1) return; //egyszer lehet aktivalni

            //Dobj! Megkapod a targyat.
            targyak.RandomTargy();
            targyak.targy_szamlalo++;
            if(!targyak.matavtaviranyitoAktivalva){
                energia.csokkenEnergia(1);
            }

            twofourText.text = "X";
            helyszinAktivalasSzamlalo[10]++;
        }
        //12-es mezo
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 4)
        {
            if(helyszinAktivalasSzamlalo[11] == 2) return; //ketszer lehet aktivalni

            //+1 elet
            elet.Eletplusz();
            if(!targyak.matavtaviranyitoAktivalva){
                akciopont.UpdateAkciopont(-1);
            }

            threefourText[helyszinAktivalasSzamlalo[11]].text = "X";
            helyszinAktivalasSzamlalo[11]++;
        }
    }
}