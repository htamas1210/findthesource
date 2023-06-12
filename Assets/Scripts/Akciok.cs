using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;

public class Akciok : MonoBehaviour
{
    //Betarazashoz
    public int toltenyszamlalo = 0;
    public TMP_Text[] toltenyek;

    private int tolteny_index = 3;
    private int felhasznalt_tolteny = 0;
    private int betarazott_tolteny = 3;
    
    public int getBetarazottTolteny(){ return betarazott_tolteny; }

    //
    private Akciopont ap;
    //

    //Nyomozashoz
    private movement movement;
    public TMP_Text[] nyomozas_x;
    public TMP_Text[] nyomozas_oszlop;
    private bool[,] nyomozas = new bool[4,4];

    //Hack
    public TMP_Text elso_sor_text;
    public TMP_Text[] masodik_sor;
    public TMP_Text[] harmadik_sor;
    public TMP_Text[] negyedik_sor;
    private int[] hackelt_sorok = new int[4];
    private Upgrade upgrade;
    //

    //Source
    private Source source;
    private bool alpha = false;
    private bool omega = false;
    //

    private void Awake(){
        ap = FindObjectOfType<Akciopont>();
        movement = FindObjectOfType<movement>();
        upgrade = FindObjectOfType<Upgrade>();
        source = FindObjectOfType<Source>();        
    }

    private void Start(){
        //kezdesnel karikazza be az elso harom adott toltenyt
        for (int i = 0; i < tolteny_index; i++)
        {
            toltenyek[i].text = "O";
        }
    }

    public void Betarazas(int betarazas)
    {
        if (tolteny_index < 24 && ap.getAkciopont() != 0)
        {
            if (tolteny_index + betarazas > 24)
            {
                tolteny_index = 24;
            }
            else
            {
                tolteny_index += betarazas;
            }
            //felhasznalt toltenytol megy hogy az ott levo x-et ne irja felul
            for (int i = felhasznalt_tolteny; i < tolteny_index; i++)
            {
                toltenyek[i].text = "O";
            }

            betarazott_tolteny += betarazas;
            if(betarazott_tolteny > 24){
                betarazott_tolteny = 24;
            }
            //tolteny_index++;           

            ap.UpdateAkciopont(-1);
        
            Debug.Log("Tolteny betarazva");
            Debug.Log("Betarazott toltenyek szama: " + betarazott_tolteny);
        }
    }

    public bool Loves(int elhasznalt_toltenyek)
    {
        if (felhasznalt_tolteny < betarazott_tolteny)
        {
            if (felhasznalt_tolteny + elhasznalt_toltenyek > betarazott_tolteny)
            {
                Debug.Log("Nincs eleg tolteny betarazva, tul sok lenne egyszerre felhasznalva!");
                return false;
            }
            else
            {
                felhasznalt_tolteny += elhasznalt_toltenyek;
                for (int i = 0; i < felhasznalt_tolteny; i++)
                {
                    toltenyek[i].text = "X";
                }
                betarazott_tolteny -= elhasznalt_toltenyek;
                toltenyszamlalo = toltenyszamlalo + elhasznalt_toltenyek;
            }
            return true;
        }
        else
        {
            Debug.Log("Nincs eleg tolteny");
            return false;
        }
    }


    //Nyomozas
    public void Nyomozas()
    {
        if (ap.getAkciopont() <= 0)
        {
            Debug.Log("nincs eleg akciopont");
            return;
        }

        int atirandox = movement.jelenlegi_x - 1;
        int atirandoy = movement.jelenlegi_y - 1;

        if (nyomozas[atirandoy, atirandox])
        {
            Debug.Log("Itt mar nyomoztal");
            return;
        }
        else
        {
            nyomozas[atirandoy, atirandox] = true;
        }

        int counter = 0;
        //egy sorral feljebb megy
        for (int i = 0; i < nyomozas.GetLength(0); i++)
        {
            for (int j = 0; j < nyomozas.GetLength(1); j++)
            {
                if (nyomozas[i, j])
                {
                    nyomozas_x[counter].text = "X";
                    counter++;
                    Debug.Log("counter: " + counter);
                }
                else if (!nyomozas[i, j])
                {
                    counter++;
                }
            }
        }

        ap.UpdateAkciopont(-1);

        NyomozasOszlopCheck();
    }

    private void NyomozasOszlopCheck()
    {
        int oszlop = movement.jelenlegi_x - 1;
        int nyomozas_counter = 0;

        for (int i = 0; i < 4; i++)
        {
            if (nyomozas[i, oszlop])
            {
                nyomozas_counter++;
            }
        }

        Debug.Log("nyomozas counter: " + nyomozas_counter);

        if (nyomozas_counter == 4)
        {
            ap.UpdateAkciopont(2);
            Debug.Log("Ap novelve");
            nyomozas_oszlop[oszlop].text = "X";
        }
    }


    public void Hack()
    {
        int count = 0;
        int rand;

        if (ap.getAkciopont() < upgrade.hack[upgrade.getHackIndex()])
        {   //van e eleg akicopont
            Debug.Log("nincs eleg ap a hackeleshez");
            return;
        }

        int i2 = 0;
        try
        {
            //egy sorban lett e ketszer nyomozva          
            for (int i = 0; i < 3; i++)
            {
                if (nyomozas[movement.jelenlegi_y - 1, i])
                {
                    count++;
                    Debug.Log("count: " + count);
                    i2 = i;
                }
            }
        }
        catch (IndexOutOfRangeException)
        {
            Debug.Log("hiba volt");
            Debug.Log("i: " + i2 + " y" + movement.jelenlegi_y);
        }


        //forras helyenek bejelolese
        if (count >= 2 && !hackelt_sorok.Contains(movement.jelenlegi_y))
        {
            if (movement.jelenlegi_y == 1)
            {
                elso_sor_text.text = "X";
                hackelt_sorok[movement.jelenlegi_y - 1] = movement.jelenlegi_y;
                source.isNyitva = true;
            }
            else
            {
                rand = UnityEngine.Random.Range(1, 7);
                Debug.Log("sorsolt szam: " + rand);

                if (movement.jelenlegi_y == 2)
                { //alpha, omega
                    if (rand < 4)
                    {
                        masodik_sor[0].text = "X";
                        alpha = true;
                        source.sor.Remove(3);//3. sor kiszedes
                        source.sor.Remove(4);//4. sor kiszedes
                    }
                    else
                    {
                        masodik_sor[1].text = "X";
                        omega = true;
                        source.sor.Remove(1);//1. sor kiszedes
                        source.sor.Remove(2);//2. sor kiszedes
                    }
                    hackelt_sorok[movement.jelenlegi_y - 1] = movement.jelenlegi_y;
                }
                else if (movement.jelenlegi_y == 3)
                {//sor
                    if (rand < 4)
                    {
                        harmadik_sor[0].text = "X";
                        source.sor.Remove(2);//2. sor kiszedes
                        source.sor.Remove(4);//4. sor kiszedes
                    }
                    else
                    {
                        harmadik_sor[1].text = "X";
                        source.sor.Remove(1);//2. sor kiszedes
                        source.sor.Remove(3);//4. sor kiszedes
                    }
                    hackelt_sorok[movement.jelenlegi_y - 1] = movement.jelenlegi_y;
                }
                else if (movement.jelenlegi_y == 4)
                {
                    if (rand < 3)
                    {
                        negyedik_sor[0].text = "X";
                        source.oszlop = 1;
                    }
                    else if (rand < 5)
                    {
                        negyedik_sor[1].text = "X";
                        source.oszlop = 2;
                    }
                    else
                    {
                        negyedik_sor[2].text = "X";
                        source.oszlop = 3;
                    }
                    hackelt_sorok[movement.jelenlegi_y - 1] = movement.jelenlegi_y;
                }
            }

            ap.UpdateAkciopont(-upgrade.hack[upgrade.getHackIndex()]); //ap koltseg levonasa
        }
        else
        {
            Debug.Log("itt mar hackeltel");
        }
    }
}