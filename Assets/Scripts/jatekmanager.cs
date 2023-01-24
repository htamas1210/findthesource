using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;

public class jatekmanager : MonoBehaviour
{
    //game objectek implementálása
    public GameObject energiafejlesztés;
    public GameObject akciofejlesztés;
    public GameObject harcfejlesztés;
    public GameObject ujradobasfejlesztés;
    public GameObject hackfejlesztés;
    public GameObject kovetkezokor;
    public GameObject betarazas;
    public GameObject nyomozas;
    public GameObject hackeles;
    public GameObject rolldice;
    public GameObject test;


    //script-ek implementalasa
    private Elet elet;
    private Akciok akciok;
    private Targyak targyak;
    private Dice dice;
    private Upgrade upgrade;
    private Akciopont akciopont;
    private movement movement;
    private TurnManager turnManager;
    private Source source;

    //ügynökcsapatok implementálása
    public TMP_Text[] oneone;
    public TMP_Text[] twoone;
    public TMP_Text[] threeone;
    public TMP_Text[] onetwo;
    public TMP_Text[] twotwo;
    public TMP_Text[] threetwo;
    public TMP_Text[] onethree;
    public TMP_Text[] twothree;
    public TMP_Text[] threethree;
    public TMP_Text[] onefour;
    public TMP_Text[] twofour;
    public TMP_Text[] threefour;

    //nyert es vesztett bool lethrehozas
    public bool jatekosnyert = false;
    public bool jatekosvesztett = false;

    private void Start()
    {
        elet = FindObjectOfType<Elet>();
        akciok = FindObjectOfType<Akciok>();
        targyak = FindObjectOfType<Targyak>();
        dice = FindObjectOfType<Dice>();
        upgrade = FindObjectOfType<Upgrade>();
        akciopont = FindObjectOfType<Akciopont>();
        movement = FindObjectOfType<movement>();
        turnManager = FindObjectOfType<TurnManager>();
        source = FindObjectOfType<Source>();

    }

    // Update is called once per frame
    void Update()
    {
        //amig a játékos vesztett bool nem egyenlo true-val vagy a nyert bool nem egyenlo true-val
        while (jatekosnyert != true || jatekosvesztett != true)
        {
            //a jatekos mikor belép semmit ne tudjon csinálni csak dobni a kockával, hogy elkezdje a játékot

            //Itt a movement script kikapcsol

            energiafejlesztés.SetActive(false);
            akciofejlesztés.SetActive(false);
            harcfejlesztés.SetActive(false);
            ujradobasfejlesztés.SetActive(false);
            hackfejlesztés.SetActive(false);
            kovetkezokor.SetActive(false);
            betarazas.SetActive(false);
            nyomozas.SetActive(false);
            hackeles.SetActive(false);
            test.SetActive(false);

            while (dice.dobott < upgrade.getUjradobasIndex() + 1 && dice.getLocked() != true)
            {

                //eddig újradobhat
            }

            rolldice.SetActive(false);

            //a játékos választ a két érték között

            if (upgrade.canUpgrade == true)
            {
                //ha a kisebbet választotta akkor jelennek meg a fejlesztés gombjai
                energiafejlesztés.SetActive(true);
                akciofejlesztés.SetActive(true);
                harcfejlesztés.SetActive(true);
                ujradobasfejlesztés.SetActive(true);
                hackfejlesztés.SetActive(true);
                kovetkezokor.SetActive(true);
            }
            else
            {
                //ha a nagyobbat választotta akkor jelennek meg az akciók gombjai

                //itt a movement bekapcsol
                kovetkezokor.SetActive(true);
                betarazas.SetActive(true);
                nyomozas.SetActive(true);
                hackeles.SetActive(true);
            }


            if (akciopont.akciopont == 0)
            {

                //movement kikapcs
                energiafejlesztés.SetActive(false);
                akciofejlesztés.SetActive(false);
                harcfejlesztés.SetActive(false);
                ujradobasfejlesztés.SetActive(false);
                hackfejlesztés.SetActive(false);
                rolldice.SetActive(false);
                betarazas.SetActive(false);
                nyomozas.SetActive(false);
                hackeles.SetActive(false);
                test.SetActive(false);
                kovetkezokor.SetActive(true);
            }
            //amint rányom a kör vége gombra 0 legyen az akciópont és megint csak a dobás legyen elérhető


        }


    }

    public void JatekosNyert()
    {
        if (source.isNyitva == true && source.oszlop == movement.jelenlegi_y && source.sor[0] == movement.jelenlegi_x) //+ ugynokcsapat oles a helyszinen
        {
            if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 1)
            {
                if (oneone[0].text.Equals("X") && oneone[1].text.Equals("X") && oneone[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                }
            }
            if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 2)
            {
                if (onetwo[0].text.Equals("X") && onetwo[1].text.Equals("X") && onetwo[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                }
            }
            if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 3)
            {
                if (onethree[0].text.Equals("X") && onethree[1].text.Equals("X") && onethree[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                }
            }
            if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 1)
            {
                if (twoone[0].text.Equals("X") && twoone[1].text.Equals("X") && twoone[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                }
            }
            if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 2)
            {
                if (twotwo[0].text.Equals("X") && twotwo[1].text.Equals("X") && twotwo[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                }
            }
            if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 3)
            {
                if (twothree[0].text.Equals("X") && twothree[1].text.Equals("X") && twothree[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                }
            }
            if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 1)
            {
                if (threeone[0].text.Equals("X") && threeone[1].text.Equals("X") && threeone[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                }
            }
            if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 2)
            {
                if (threetwo[0].text.Equals("X") && threetwo[1].text.Equals("X") && threetwo[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                }
            }
            if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 3)
            {
                if (threethree[0].text.Equals("X") && threethree[1].text.Equals("X") && threethree[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                }
            }
            if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 4)
            {
                if (onefour[0].text.Equals("X") && onefour[1].text.Equals("X") && onefour[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                }
            }
            if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 4)
            {
                if (twofour[0].text.Equals("X") && twofour[1].text.Equals("X") && twofour[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                }
            }
            if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 4)
            {
                if (threefour[0].text.Equals("X") && threefour[1].text.Equals("X") && threefour[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                }
            }
        }

    }

    public void JatekosVesztett()
    {
        //ha kinyilik a forras de mar voltal ott ketszer
        if (source.isNyitva == true)
        {
            if (source.sor[0] == 1 && source.oszlop == 1)
            {
                if (movement.eromulepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 1)
                    {

                    }
                    else
                    {
                        jatekosvesztett = false;
                    }
                }
            }
            if (source.sor[0] == 2 && source.oszlop == 1)
            {
                if (movement.feketepiaclepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 1)
                    {

                    }
                    else
                    {
                        jatekosvesztett = false;
                    }
                }
            }
            if (source.sor[0] == 3 && source.oszlop == 1)
            {
                if (movement.metrolepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 1)
                    {

                    }
                    else
                    {
                        jatekosvesztett = false;
                    }
                }
            }
            if (source.sor[0] == 1 && source.oszlop == 2)
            {
                if (movement.szervereklepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 2)
                    {

                    }
                    else
                    {
                        jatekosvesztett = false;
                    }
                }
            }
            if (source.sor[0] == 2 && source.oszlop == 2)
            {
                if (movement.kingcasinolepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 2)
                    {

                    }
                    else
                    {
                        jatekosvesztett = false;
                    }
                }
            }
            if (source.sor[0] == 3 && source.oszlop == 2)
            {
                if (movement.feltoltolepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 2)
                    {

                    }
                    else
                    {
                        jatekosvesztett = false;
                    }
                }
            }
            if (source.sor[0] == 1 && source.oszlop == 3)
            {
                if (movement.kutatolaborlepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 3)
                    {

                    }
                    else
                    {
                        jatekosvesztett = false;
                    }
                }
            }
            if (source.sor[0] == 2 && source.oszlop == 3)
            {
                if (movement.kriptoklublepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 3)
                    {

                    }
                    else
                    {
                        jatekosvesztett = false;
                    }
                }
            }
            if (source.sor[0] == 3 && source.oszlop == 3)
            {
                if (movement.cyberplazalepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 3)
                    {

                    }
                    else
                    {
                        jatekosvesztett = false;
                    }
                }
            }
            if (source.sor[0] == 1 && source.oszlop == 4)
            {
                if (movement.hadiuzemlepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 4)
                    {

                    }
                    else
                    {
                        jatekosvesztett = false;
                    }
                }
            }
            if (source.sor[0] == 2 && source.oszlop == 4)
            {
                if (movement.konyvtarlepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 4)
                    {

                    }
                    else
                    {
                        jatekosvesztett = false;
                    }
                }
            }
            if (source.sor[0] == 3 && source.oszlop == 4)
            {
                if (movement.korhazlepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 4)
                    {

                    }
                    else
                    {
                        jatekosvesztett = false;
                    }
                }
            }
        }

        //ha elfogy a töltényed mielőtt végzel a source-nál lévő ügynökcsapatokkal

        if (source.isNyitva == true && akciok.toltenyszamlalo >= 24)
        {
            if (source.sor[0] == 1 && source.oszlop == 1)
            {
                if (oneone[0].text.Equals("X") == false || oneone[1].text.Equals("X") == false || oneone[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
            if (source.sor[0] == 2 && source.oszlop == 1)
            {
                if (twoone[0].text.Equals("X") == false || twoone[1].text.Equals("X") == false || twoone[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
            if (source.sor[0] == 3 && source.oszlop == 1)
            {
                if (threeone[0].text.Equals("X") == false || threeone[1].text.Equals("X") == false || threeone[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
            if (source.sor[0] == 1 && source.oszlop == 2)
            {
                if (onetwo[0].text.Equals("X") == false || onetwo[1].text.Equals("X") == false || onetwo[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
            if (source.sor[0] == 2 && source.oszlop == 2)
            {
                if (twotwo[0].text.Equals("X") == false || twotwo[1].text.Equals("X") == false || twotwo[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
            if (source.sor[0] == 3 && source.oszlop == 2)
            {
                if (threetwo[0].text.Equals("X") == false || threetwo[1].text.Equals("X") == false || threetwo[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
            if (source.sor[0] == 1 && source.oszlop == 3)
            {
                if (onethree[0].text.Equals("X") == false || onethree[1].text.Equals("X") == false || onethree[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
            if (source.sor[0] == 2 && source.oszlop == 3)
            {
                if (twothree[0].text.Equals("X") == false || twothree[1].text.Equals("X") == false || twothree[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
            if (source.sor[0] == 3 && source.oszlop == 3)
            {
                if (threethree[0].text.Equals("X") == false || threethree[1].text.Equals("X") == false || threethree[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
            if (source.sor[0] == 1 && source.oszlop == 4)
            {
                if (onefour[0].text.Equals("X") == false || onefour[1].text.Equals("X") == false || onefour[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
            if (source.sor[0] == 2 && source.oszlop == 4)
            {
                if (twofour[0].text.Equals("X") == false || twofour[1].text.Equals("X") == false || twofour[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
            if (source.sor[0] == 3 && source.oszlop == 4)
            {
                if (threefour[0].text.Equals("X") == false || threefour[1].text.Equals("X") == false || threefour[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
        }

    }
}
