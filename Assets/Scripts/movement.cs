using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using TMPro;


public class movement : MonoBehaviour
{
    public Camera THE_Camera;
    public GameObject player;

    public GameObject oneone;
    public Collider2D oneone_Collider;
    public GameObject eromulepes1;
    public GameObject eromulepes2;

    public GameObject twoone;
    public Collider2D twoone_Collider;
    public GameObject feketepiaclepes1;
    public GameObject feketepiaclepes2;

    public GameObject threeone;
    public Collider2D threeone_Collider;
    public GameObject metrolepes1;
    public GameObject metrolepes2;

    public GameObject onetwo;
    public Collider2D onetwo_Collider;
    public GameObject szervereklepes1;
    public GameObject szervereklepes2;

    public GameObject twotwo;
    public Collider2D twotwo_Collider;
    public GameObject kingcasinolepes1;
    public GameObject kingcasinolepes2;

    public GameObject threetwo;
    public Collider2D threetwo_Collider;
    public GameObject feltoltolepes1;
    public GameObject feltoltolepes2;

    public GameObject onethree;
    public Collider2D onethree_Collider;
    public GameObject kutatolaborlepes1;
    public GameObject kutatolaborlepes2;

    public GameObject twothree;
    public Collider2D twothree_Collider;
    public GameObject kriptoklublepes1;
    public GameObject kriptoklublepes2;

    public GameObject threethree;
    public Collider2D threethree_Collider;
    public GameObject cyberplazalepes1;
    public GameObject cyberplazalepes2;

    public GameObject onefour;
    public Collider2D onefour_Collider;
    public GameObject hadiuzemlepes1;
    public GameObject hadiuzemlepes2;

    public GameObject twofour;
    public Collider2D twofour_Collider;
    public GameObject konyvtarlepes1;
    public GameObject konyvtarlepes2;

    public GameObject threefour;
    public Collider2D threefour_Collider;
    public GameObject korhazlepes1;
    public GameObject korhazlepes2;

    private Akciopont ap;
    private Ugynok ugynok;
    private Targyak targyak;
    private jatekmanager jatekmanager;
    private Dice dice;
    private Kezdohelyszin kezdohelyszin;

    private int oneonecount = 0;
    private int twoonecount = 0;
    private int threeonecount = 0;
    private int onetwocount = 0;
    private int twotwocount = 0;
    private int threetwocount = 0;
    private int onethreecount = 0;
    private int twothreecount = 0;
    private int threethreecount = 0;
    private int onefourcount = 0;
    private int twofourcount = 0;
    private int threefourcount = 0;

    private int w = 3; //ennyi oszlop van a mapon
    private int h = 4; //ennyi sor van a mapon

    public int jelenlegi_x = 1;
    public int jelenlegi_y = 1;
    private int tavolsag = 0;
    private int moveCounter = 1;

    private void Awake()
    {
        ap = FindObjectOfType<Akciopont>();
        ugynok = FindObjectOfType<Ugynok>();
        targyak = FindObjectOfType<Targyak>();
        jatekmanager = FindObjectOfType<jatekmanager>();
        dice = FindObjectOfType<Dice>();
        kezdohelyszin = FindObjectOfType<Kezdohelyszin>();
    }

    private void Start()
    {
        eromulepes1.SetActive(false);
        eromulepes2.SetActive(false);

        feketepiaclepes1.SetActive(false);
        feketepiaclepes2.SetActive(false);

        metrolepes1.SetActive(false);
        metrolepes2.SetActive(false);

        szervereklepes1.SetActive(false);
        szervereklepes2.SetActive(false);

        kingcasinolepes1.SetActive(false);
        kingcasinolepes2.SetActive(false);

        feltoltolepes1.SetActive(false);
        feltoltolepes2.SetActive(false);

        kutatolaborlepes1.SetActive(false);
        kutatolaborlepes2.SetActive(false);

        kriptoklublepes1.SetActive(false);
        kriptoklublepes2.SetActive(false);

        cyberplazalepes1.SetActive(false);
        cyberplazalepes2.SetActive(false);

        hadiuzemlepes1.SetActive(false);
        hadiuzemlepes2.SetActive(false);

        konyvtarlepes1.SetActive(false);
        konyvtarlepes2.SetActive(false);

        korhazlepes1.SetActive(false);
        korhazlepes2.SetActive(false);

        kezdoHelyMeghatarzoas();
    }

    private void kezdoHelyMeghatarzoas()
    {
        int random = UnityEngine.Random.Range(1, 12);
        Debug.Log("Random a kezdohelyszinhez: " + random);
        string helynev = "";

        if (random == 1)
        {
            player.transform.position = oneone.transform.position;
            eromulepes1.SetActive(true);
            eromulepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 1;
            jelenlegi_y = 1;
            helynev = "Erőmű";
        }
        else if (random == 2)
        {
            player.transform.position = twoone.transform.position;
            feketepiaclepes1.SetActive(true);
            feketepiaclepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 2;
            jelenlegi_y = 1;
            helynev = "Fekete piac";
        }
        else if (random == 3)
        {
            player.transform.position = threeone.transform.position;
            metrolepes1.SetActive(true);
            metrolepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 3;
            jelenlegi_y = 1;
            helynev = "Metró";
        }
        else if (random == 4)
        {
            player.transform.position = onetwo.transform.position;
            szervereklepes1.SetActive(true);
            szervereklepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 1;
            jelenlegi_y = 2;
            helynev = "Szerverek";
        }
        else if (random == 5)
        {
            player.transform.position = twotwo.transform.position;
            kingcasinolepes1.SetActive(true);
            kingcasinolepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 2;
            jelenlegi_y = 2;
            helynev = "King Kaszinó";
        }
        else if (random == 6)
        {
            player.transform.position = threetwo.transform.position;
            feltoltolepes1.SetActive(true);
            feltoltolepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 3;
            jelenlegi_y = 2;
            helynev = "Feltöltő";
        }
        else if (random == 7)
        {
            player.transform.position = onethree.transform.position;
            kutatolaborlepes1.SetActive(true);
            kutatolaborlepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 1;
            jelenlegi_y = 3;
            helynev = "Kutatólabor";
        }
        else if (random == 8)
        {
            player.transform.position = twothree.transform.position;
            kriptoklublepes1.SetActive(true);
            kriptoklublepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 2;
            jelenlegi_y = 3;
            helynev = "Kripto club";
        }
        else if (random == 9)
        {
            player.transform.position = threethree.transform.position;
            cyberplazalepes1.SetActive(true);
            cyberplazalepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 3;
            jelenlegi_y = 3;
            helynev = "Cyber pláza";
        }
        else if (random == 10)
        {
            player.transform.position = onefour.transform.position;
            hadiuzemlepes1.SetActive(true);
            hadiuzemlepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 1;
            jelenlegi_y = 4;
            helynev = "Hadiüzem";
        }
        else if (random == 11)
        {
            player.transform.position = twofour.transform.position;
            konyvtarlepes1.SetActive(true);
            konyvtarlepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 2;
            jelenlegi_y = 4;
            helynev = "Könyvtár";
        }
        else if (random == 12)
        {
            player.transform.position = threefour.transform.position;
            korhazlepes1.SetActive(true);
            korhazlepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 3;
            jelenlegi_y = 4;
            helynev = "Kórház";
        }

        kezdohelyszin.KezdoHelyszinSorsolas(jelenlegi_x, jelenlegi_y, helynev);
        //ugynok.UgynokSorsolas(jelenlegi_x, jelenlegi_y);
        ugynok.setElozoHelyszin(jelenlegi_x, jelenlegi_y);
    }

    private int Distance(int x, int y)
    {
        return math.abs((x + 1) - jelenlegi_x) + math.abs((y + 1) - jelenlegi_y);
    }

    public void Update()
    {
        //tavolsag = math.abs(tavolsag); //mindig abszolut
        ugynok.ugynokMegolveElozoHelyen();

        // player mozgatasa es konzolra iratas
        if (Input.GetKeyDown(KeyCode.Mouse0) && oneone_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            //mivel tudom melyik colliderre kattintott ezert tudom a koordinatajat
            int x = 0;
            int y = 0;

            Debug.Log("Player clicked on the collider: " + oneone_Collider.gameObject.name);

            tavolsag = Distance(x, y);

            if (eromulepes1.activeSelf == true & eromulepes2.activeSelf == true)
            {
                Debug.Log("Maximum ketszer lephetsz egy mezore");
            }
            else
            {
                if (tavolsag <= ap.getAkciopont() && tavolsag != 0) //ap.getAkciopont() > 0 || szukseges?
                {
                    player.transform.position = oneone.transform.position;
                    jelenlegi_x = 1;
                    jelenlegi_y = 1;
                    if (targyak.lathatatlanOltozetAktivalva)
                    {
                        targyak.lathatatlanOltozetAktivalva = false;
                    }
                    else
                    {
                        //ap.akciopont = ap.akciopont - tavolsag;
                        ap.UpdateAkciopont(-tavolsag);
                    }


                    oneonecount = oneonecount + 1;

                    Debug.Log(ap.getAkciopont());
                    Debug.Log("ugynok sorsolas");
                    //ugynok.UgynokSorsolas(jelenlegi_x, jelenlegi_y);

                    jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.UgynokValasztas); //ne lepjen addig tovabb amig nem valasztott

                    dice.CallRenderDice(true);
                    ugynok.ugynokMegolveElozoHelyen();

                    if (eromulepes1.activeSelf == true)
                    {
                        eromulepes2.SetActive(true);
                        moveCounter++;
                        eromulepes2.GetComponent<TMP_Text>().text = moveCounter.ToString();
                    }
                    else
                    {
                        eromulepes1.SetActive(true);
                        moveCounter++;
                        eromulepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
                    }
                    jatekmanager.JatekosVesztett();
                }
                else
                {
                    Debug.Log("Nincs eleg akciopontod vagy nem 1 mez?n belul akarsz lepni");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && twoone_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            Debug.Log("Player clicked on the collider: " + twoone_Collider.gameObject.name);

            int x = 1;
            int y = 0;
            tavolsag = Distance(x, y);

            if (feketepiaclepes1.activeSelf == true & feketepiaclepes2.activeSelf == true)
            {
                Debug.Log("Maximum ketszer lephetsz egy mezore");
            }
            else
            {
                if (tavolsag <= ap.getAkciopont() && tavolsag != 0) //&& ap.getAkciopont() > 0
                {
                    if (jelenlegi_x == 1 && jelenlegi_y == 2)
                    {
                        tavolsag = 2;
                    }
                    if (twoonecount < 2)
                    {
                        player.transform.position = twoone.transform.position;
                        jelenlegi_x = 2;
                        jelenlegi_y = 1;
                        if (targyak.lathatatlanOltozetAktivalva)
                        {
                            targyak.lathatatlanOltozetAktivalva = false;
                        }
                        else
                        {
                            //ap.akciopont = ap.akciopont - tavolsag;
                            ap.UpdateAkciopont(-tavolsag);
                        }
                        twoonecount = twoonecount + 1;
                        Debug.Log(ap.getAkciopont()); Debug.Log("ugynok sorsolas");
                        //ugynok.UgynokSorsolas(jelenlegi_x, jelenlegi_y);
                        jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.UgynokValasztas); //ne lepjen addig tovabb amig nem valasztott
                        dice.CallRenderDice(true);
                        ugynok.ugynokMegolveElozoHelyen();
                        if (feketepiaclepes1.activeSelf == true)
                        {
                            feketepiaclepes2.SetActive(true);
                            moveCounter++;
                            feketepiaclepes2.GetComponent<TMP_Text>().text = moveCounter.ToString();
                        }
                        else
                        {
                            feketepiaclepes1.SetActive(true);
                            moveCounter++;
                            feketepiaclepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
                        }
                        jatekmanager.JatekosVesztett();
                    }
                    else
                    {
                        Debug.Log("Maximum ketszer lephetsz egy mez?re");
                    }
                }
                else
                {
                    Debug.Log("Nincs eleg akciopontod vagy nem 1 mez?n belul akarsz lepni");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && threeone_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            Debug.Log("Player clicked on the collider: " + threeone_Collider.gameObject.name);

            int x = 2;
            int y = 0;
            tavolsag = Distance(x, y);

            if (metrolepes1.activeSelf == true & metrolepes2.activeSelf == true)
            {
                Debug.Log("Maximum ketszer lephetsz egy mezore");
            }
            else
            {
                if (tavolsag <= ap.getAkciopont() && tavolsag != 0) // && ap.getAkciopont() > 0
                {
                    if (threeonecount < 2)
                    {
                        player.transform.position = threeone.transform.position;
                        jelenlegi_x = 3;
                        jelenlegi_y = 1;
                        if (targyak.lathatatlanOltozetAktivalva)
                        {
                            targyak.lathatatlanOltozetAktivalva = false;
                        }
                        else
                        {
                            //ap.akciopont = ap.akciopont - tavolsag;
                            ap.UpdateAkciopont(-tavolsag);
                        }
                        threeonecount++;
                        Debug.Log(ap.getAkciopont());
                        Debug.Log("ugynok sorsolas");
                        //ugynok.UgynokSorsolas(jelenlegi_x, jelenlegi_y);
                        jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.UgynokValasztas); //ne lepjen addig tovabb amig nem valasztott
                        dice.CallRenderDice(true);
                        ugynok.ugynokMegolveElozoHelyen();
                        if (metrolepes1.activeSelf == true)
                        {
                            metrolepes2.SetActive(true);
                            moveCounter++;
                            metrolepes2.GetComponent<TMP_Text>().text = moveCounter.ToString();
                        }
                        else
                        {
                            metrolepes1.SetActive(true);
                            moveCounter++;
                            metrolepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
                        }
                        jatekmanager.JatekosVesztett();
                    }
                    else
                    {
                        Debug.Log("Maximum ketszer lephetsz egy mezore");
                    }
                }
                else
                {
                    Debug.Log("Nincs eleg akciopontod vagy nem 1 mez?n belul akarsz lepni");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && onetwo_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            Debug.Log("Player clicked on the collider: " + onetwo_Collider.gameObject.name);

            int x = 0;
            int y = 1;
            tavolsag = Distance(x, y);

            if (szervereklepes1.activeSelf == true & szervereklepes2.activeSelf == true)
            {
                Debug.Log("Maximum ketszer lephetsz egy mezore");
            }
            else
            {
                if (tavolsag <= ap.getAkciopont() && tavolsag != 0) // && ap.getAkciopont() > 0
                {
                    if (jelenlegi_x == 2 && jelenlegi_y == 1)
                    {
                        tavolsag = 2;
                    }
                    if (onetwocount < 2)
                    {
                        player.transform.position = onetwo.transform.position;
                        jelenlegi_x = 1;
                        jelenlegi_y = 2;
                        if (targyak.lathatatlanOltozetAktivalva)
                        {
                            targyak.lathatatlanOltozetAktivalva = false;
                        }
                        else
                        {
                            //ap.akciopont = ap.akciopont - tavolsag;
                            ap.UpdateAkciopont(-tavolsag);
                        }
                        onetwocount++;
                        Debug.Log(ap.getAkciopont());
                        Debug.Log("ugynok sorsolas");
                        //ugynok.UgynokSorsolas(jelenlegi_x, jelenlegi_y);
                        jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.UgynokValasztas); //ne lepjen addig tovabb amig nem valasztott
                        dice.CallRenderDice(true);
                        ugynok.ugynokMegolveElozoHelyen();
                        if (szervereklepes1.activeSelf == true)
                        {
                            szervereklepes2.SetActive(true);
                            moveCounter++;
                            szervereklepes2.GetComponent<TMP_Text>().text = moveCounter.ToString();
                        }
                        else
                        {
                            szervereklepes1.SetActive(true);
                            moveCounter++;
                            szervereklepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
                        }
                        jatekmanager.JatekosVesztett();
                    }
                    else
                    {
                        Debug.Log("Maximum ketszer lephetsz egy mezore");
                    }
                }
                else
                {
                    Debug.Log("Nincs eleg akciopontod vagy nem 1 mezon belul akarsz lepni");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && twotwo_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            Debug.Log("Player clicked on the collider: " + twotwo_Collider.gameObject.name);

            int x = 1;
            int y = 1;
            tavolsag = Distance(x, y);

            if (kingcasinolepes1.activeSelf == true & kingcasinolepes2.activeSelf == true)
            {
                Debug.Log("Maximum ketszer lephetsz egy mezore");
            }
            else
            {
                if (tavolsag <= ap.getAkciopont() && tavolsag != 0) //&& ap.getAkciopont() > 0 
                {
                    if (twotwocount < 2)
                    {
                        player.transform.position = twotwo.transform.position;
                        jelenlegi_x = 2;
                        jelenlegi_y = 2;
                        if (targyak.lathatatlanOltozetAktivalva)
                        {
                            targyak.lathatatlanOltozetAktivalva = false;
                        }
                        else
                        {
                            //ap.akciopont = ap.akciopont - tavolsag;
                            ap.UpdateAkciopont(-tavolsag);
                        }
                        Debug.Log(ap.getAkciopont());
                        Debug.Log("ugynok sorsolas");
                        //ugynok.UgynokSorsolas(jelenlegi_x, jelenlegi_y);
                        jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.UgynokValasztas); //ne lepjen addig tovabb amig nem valasztott
                        dice.CallRenderDice(true);
                        ugynok.ugynokMegolveElozoHelyen();
                        twotwocount++;
                        if (kingcasinolepes1.activeSelf == true)
                        {
                            kingcasinolepes2.SetActive(true);
                            moveCounter++;
                            kingcasinolepes2.GetComponent<TMP_Text>().text = moveCounter.ToString();
                        }
                        else
                        {
                            kingcasinolepes1.SetActive(true);
                            moveCounter++;
                            kingcasinolepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
                        }
                        jatekmanager.JatekosVesztett();
                    }
                    else
                    {
                        Debug.Log("Maximum ketszer lephetsz egy mezore");
                    }
                }
                else
                {
                    Debug.Log("Nincs eleg akciopontod vagy nem 1 mezon belul akarsz lepni");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && threetwo_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            Debug.Log("Player clicked on the collider: " + threetwo_Collider.gameObject.name);

            int x = 2;
            int y = 1;
            tavolsag = Distance(x, y);

            if (feltoltolepes1.activeSelf == true & feltoltolepes2.activeSelf == true)
            {
                Debug.Log("Maximum ketszer lephetsz egy mezore");
            }
            else
            {
                if (tavolsag <= ap.getAkciopont() && tavolsag != 0) //ap.getAkciopont() > 0 && 
                {
                    if (jelenlegi_x == 2 && jelenlegi_y == 3)
                    {
                        tavolsag = 2;
                    }
                    if (threetwocount < 2)
                    {
                        player.transform.position = threetwo.transform.position;
                        jelenlegi_x = 3;
                        jelenlegi_y = 2;
                        if (targyak.lathatatlanOltozetAktivalva)
                        {
                            targyak.lathatatlanOltozetAktivalva = false;
                        }
                        else
                        {
                            //ap.akciopont = ap.akciopont - tavolsag;
                            ap.UpdateAkciopont(-tavolsag);
                        }
                        Debug.Log(ap.getAkciopont());
                        Debug.Log("ugynok sorsolas");
                        //ugynok.UgynokSorsolas(jelenlegi_x, jelenlegi_y);
                        jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.UgynokValasztas); //ne lepjen addig tovabb amig nem valasztott
                        dice.CallRenderDice(true);
                        ugynok.ugynokMegolveElozoHelyen();
                        threetwocount++;
                        if (feltoltolepes1.activeSelf == true)
                        {
                            feltoltolepes2.SetActive(true);
                            moveCounter++;
                            feltoltolepes2.GetComponent<TMP_Text>().text = moveCounter.ToString();
                        }
                        else
                        {
                            feltoltolepes1.SetActive(true);
                            moveCounter++;
                            feltoltolepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
                        }
                        jatekmanager.JatekosVesztett();
                    }
                    else
                    {
                        Debug.Log("Maximum ketszer lephetsz egy mezore");
                    }
                }
                else
                {
                    Debug.Log("Nincs eleg akciopontod vagy nem 1 mezon belul akarsz lepni");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && onethree_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            Debug.Log("Player clicked on the collider: " + onethree_Collider.gameObject.name);

            int x = 0;
            int y = 2;
            tavolsag = Distance(x, y);

            if (kutatolaborlepes1.activeSelf == true & kutatolaborlepes2.activeSelf == true)
            {
                Debug.Log("Maximum ketszer lephetsz egy mezore");
            }
            else
            {
                if (tavolsag <= ap.getAkciopont() && tavolsag != 0) //&& ap.getAkciopont() > 0 
                {
                    if (onethreecount < 2)
                    {
                        player.transform.position = onethree.transform.position;
                        jelenlegi_x = 1;
                        jelenlegi_y = 3;
                        if (targyak.lathatatlanOltozetAktivalva)
                        {
                            targyak.lathatatlanOltozetAktivalva = false;
                        }
                        else
                        {
                            //ap.akciopont = ap.akciopont - tavolsag;
                            ap.UpdateAkciopont(-tavolsag);
                        }
                        Debug.Log(ap.getAkciopont());
                        Debug.Log("ugynok sorsolas");
                        //ugynok.UgynokSorsolas(jelenlegi_x, jelenlegi_y);
                        jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.UgynokValasztas); //ne lepjen addig tovabb amig nem valasztott
                        dice.CallRenderDice(true);
                        ugynok.ugynokMegolveElozoHelyen();
                        onethreecount++;
                        if (kutatolaborlepes1.activeSelf == true)
                        {
                            kutatolaborlepes2.SetActive(true);
                            moveCounter++;
                            kutatolaborlepes2.GetComponent<TMP_Text>().text = moveCounter.ToString();
                        }
                        else
                        {
                            kutatolaborlepes1.SetActive(true);
                            moveCounter++;
                            kutatolaborlepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
                        }
                        jatekmanager.JatekosVesztett();
                    }
                    else
                    {
                        Debug.Log("Maximum ketszer lephetsz egy mezore");
                    }
                }
                else
                {
                    Debug.Log("Nincs eleg akciopontod vagy nem 1 mez?n belul akarsz lepni");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && twothree_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            Debug.Log("Player clicked on the collider: " + twothree_Collider.gameObject.name);

            int x = 1;
            int y = 2;
            tavolsag = Distance(x, y);

            if (kriptoklublepes1.activeSelf == true & kriptoklublepes2.activeSelf == true)
            {
                Debug.Log("Maximum ketszer lephetsz egy mezore");
            }
            else
            {
                if (tavolsag <= ap.getAkciopont() && tavolsag != 0) //&& ap.getAkciopont() > 0 
                {
                    if (jelenlegi_x == 3 && jelenlegi_y == 2)
                    {
                        tavolsag = 2;
                    }
                    if (twothreecount < 2)
                    {
                        player.transform.position = twothree.transform.position;
                        jelenlegi_x = 2;
                        jelenlegi_y = 3;
                        if (targyak.lathatatlanOltozetAktivalva)
                        {
                            targyak.lathatatlanOltozetAktivalva = false;
                        }
                        else
                        {
                            //ap.akciopont = ap.akciopont - tavolsag;
                            ap.UpdateAkciopont(-tavolsag);
                        }
                        Debug.Log(ap.getAkciopont());
                        Debug.Log("ugynok sorsolas");
                        //ugynok.UgynokSorsolas(jelenlegi_x, jelenlegi_y);
                        jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.UgynokValasztas); //ne lepjen addig tovabb amig nem valasztott
                        dice.CallRenderDice(true);
                        ugynok.ugynokMegolveElozoHelyen();
                        twothreecount++;
                        if (kriptoklublepes1.activeSelf == true)
                        {
                            kriptoklublepes2.SetActive(true);
                            moveCounter++;
                            kriptoklublepes2.GetComponent<TMP_Text>().text = moveCounter.ToString();
                        }
                        else
                        {
                            kriptoklublepes1.SetActive(true);
                            moveCounter++;
                            kriptoklublepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
                        }
                        jatekmanager.JatekosVesztett();
                    }
                    else
                    {
                        Debug.Log("Maximum ketszer lephetsz egy mezore");
                    }
                }
                else
                {
                    Debug.Log("Nincs eleg akciopontod vagy nem 1 mezon belul akarsz lepni");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && threethree_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            Debug.Log("Player clicked on the collider: " + threethree_Collider.gameObject.name);

            int x = 2;
            int y = 2;
            tavolsag = Distance(x, y);

            if (cyberplazalepes1.activeSelf == true & cyberplazalepes2.activeSelf == true)
            {
                Debug.Log("Maximum ketszer lephetsz egy mezore");
            }
            else
            {
                if (tavolsag <= ap.getAkciopont() && tavolsag != 0) // && ap.getAkciopont() > 0
                {
                    if (threethreecount < 2)
                    {
                        player.transform.position = threethree.transform.position;
                        jelenlegi_x = 3;
                        jelenlegi_y = 3;
                        if (targyak.lathatatlanOltozetAktivalva)
                        {
                            targyak.lathatatlanOltozetAktivalva = false;
                        }
                        else
                        {
                            //ap.akciopont = ap.akciopont - tavolsag;
                            ap.UpdateAkciopont(-tavolsag);
                        }
                        Debug.Log(ap.getAkciopont());
                        Debug.Log("ugynok sorsolas");
                        //ugynok.UgynokSorsolas(jelenlegi_x, jelenlegi_y);
                        jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.UgynokValasztas); //ne lepjen addig tovabb amig nem valasztott
                        dice.CallRenderDice(true);
                        ugynok.ugynokMegolveElozoHelyen();
                        threethreecount++;
                        if (cyberplazalepes1.activeSelf == true)
                        {
                            cyberplazalepes2.SetActive(true);
                            moveCounter++;
                            cyberplazalepes2.GetComponent<TMP_Text>().text = moveCounter.ToString();
                        }
                        else
                        {
                            cyberplazalepes1.SetActive(true);
                            moveCounter++;
                            cyberplazalepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
                        }
                        jatekmanager.JatekosVesztett();
                    }
                    else
                    {
                        Debug.Log("Maximum ketszer lephetsz egy mezore");
                    }
                }
                else
                {
                    Debug.Log("Nincs eleg akciopontod vagy nem 1 mezon belul akarsz lepni");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && onefour_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            Debug.Log("Player clicked on the collider: " + onefour_Collider.gameObject.name);

            int x = 0;
            int y = 3;
            tavolsag = Distance(x, y);

            if (hadiuzemlepes1.activeSelf == true & hadiuzemlepes2.activeSelf == true)
            {
                Debug.Log("Maximum ketszer lephetsz egy mezore");
            }
            else
            {
                if (tavolsag <= ap.getAkciopont() && tavolsag != 0) //ap.getAkciopont() > 0 && 
                {
                    if (onefourcount < 2)
                    {
                        player.transform.position = onefour.transform.position;
                        jelenlegi_x = 1;
                        jelenlegi_y = 4;
                        if (targyak.lathatatlanOltozetAktivalva)
                        {
                            targyak.lathatatlanOltozetAktivalva = false;
                        }
                        else
                        {
                            //ap.akciopont = ap.akciopont - tavolsag;
                            ap.UpdateAkciopont(-tavolsag);
                        }
                        Debug.Log(ap.getAkciopont());
                        Debug.Log("ugynok sorsolas");
                        //ugynok.UgynokSorsolas(jelenlegi_x, jelenlegi_y);
                        jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.UgynokValasztas); //ne lepjen addig tovabb amig nem valasztott
                        dice.CallRenderDice(true);
                        ugynok.ugynokMegolveElozoHelyen();
                        onefourcount++;
                        if (hadiuzemlepes1.activeSelf == true)
                        {
                            hadiuzemlepes2.SetActive(true);
                            moveCounter++;
                            hadiuzemlepes2.GetComponent<TMP_Text>().text = moveCounter.ToString();
                        }
                        else
                        {
                            hadiuzemlepes1.SetActive(true);
                            moveCounter++;
                            hadiuzemlepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
                        }
                        jatekmanager.JatekosVesztett();
                    }
                    else
                    {
                        Debug.Log("Maximum ketszer lephetsz egy mezore");
                    }
                }
                else
                {
                    Debug.Log("Nincs eleg akciopontod vagy nem 1 mez?n belul akarsz lepni");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && twofour_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            Debug.Log("Player clicked on the collider: " + twofour_Collider.gameObject.name);

            int x = 1;
            int y = 3;
            tavolsag = Distance(x, y);

            if (konyvtarlepes1.activeSelf == true & konyvtarlepes2.activeSelf == true)
            {
                Debug.Log("Maximum ketszer lephetsz egy mezore");
            }
            else
            {
                if (tavolsag <= ap.getAkciopont() && tavolsag != 0) //&& ap.getAkciopont() > 0 
                {
                    if (twofourcount < 2)
                    {
                        player.transform.position = twofour.transform.position;
                        jelenlegi_x = 2;
                        jelenlegi_y = 4;
                        if (targyak.lathatatlanOltozetAktivalva)
                        {
                            targyak.lathatatlanOltozetAktivalva = false;
                        }
                        else
                        {
                            //ap.akciopont = ap.akciopont - tavolsag;
                            ap.UpdateAkciopont(-tavolsag);
                        }
                        Debug.Log(ap.getAkciopont());
                        Debug.Log("ugynok sorsolas");
                        //ugynok.UgynokSorsolas(jelenlegi_x, jelenlegi_y);
                        jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.UgynokValasztas); //ne lepjen addig tovabb amig nem valasztott
                        dice.CallRenderDice(true);
                        ugynok.ugynokMegolveElozoHelyen();
                        twofourcount++;
                        if (konyvtarlepes1.activeSelf == true)
                        {
                            konyvtarlepes2.SetActive(true);
                            moveCounter++;
                            konyvtarlepes2.GetComponent<TMP_Text>().text = moveCounter.ToString();
                        }
                        else
                        {
                            konyvtarlepes1.SetActive(true);
                            moveCounter++;
                            konyvtarlepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
                        }
                        jatekmanager.JatekosVesztett();
                    }
                    else
                    {
                        Debug.Log("Maximum ketszer lephetsz egy mezore");
                    }
                }
                else
                {
                    Debug.Log("Nincs eleg akciopontod vagy nem 1 mezon belul akarsz lepni");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && threefour_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            Debug.Log("Player clicked on the collider: " + threefour_Collider.gameObject.name);

            int x = 2;
            int y = 3;
            tavolsag = Distance(x, y);

            if (korhazlepes1.activeSelf == true & korhazlepes2.activeSelf == true)
            {
                Debug.Log("Maximum ketszer lephetsz egy mezore");
            }
            else
            {
                if (tavolsag <= ap.getAkciopont() && tavolsag != 0) //&& ap.getAkciopont() > 0 
                {
                    if (threefourcount < 2)
                    {
                        player.transform.position = threefour.transform.position;
                        jelenlegi_x = 3;
                        jelenlegi_y = 4;
                        if (targyak.lathatatlanOltozetAktivalva)
                        {
                            targyak.lathatatlanOltozetAktivalva = false;
                        }
                        else
                        {
                            //ap.akciopont = ap.akciopont - tavolsag;
                            ap.UpdateAkciopont(-tavolsag);
                        }
                        Debug.Log(ap.getAkciopont());
                        Debug.Log("ugynok sorsolas");
                        //ugynok.UgynokSorsolas(jelenlegi_x, jelenlegi_y);
                        jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.UgynokValasztas); //ne lepjen addig tovabb amig nem valasztott
                        dice.CallRenderDice(true);
                        ugynok.ugynokMegolveElozoHelyen();
                        threefourcount++;
                        if (korhazlepes1.activeSelf == true)
                        {
                            korhazlepes2.SetActive(true);
                            moveCounter++;
                            korhazlepes2.GetComponent<TMP_Text>().text = moveCounter.ToString();
                        }
                        else
                        {
                            korhazlepes1.SetActive(true);
                            moveCounter++;
                            korhazlepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
                        }
                        jatekmanager.JatekosVesztett();
                    }
                    else
                    {
                        Debug.Log("Maximum ketszer lephetsz egy mezore");
                    }
                }
                else
                {
                    Debug.Log("Nincs eleg akciopontod vagy nem 1 mezon belul akarsz lepni");
                }
            }

        }
    }
}