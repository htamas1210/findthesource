using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using TMPro;


public class movement : MonoBehaviour {
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

    private int jelenlegi_x = 1;
    private int jelenlegi_y = 1;
    private int tavolsag = 0;
    private int moveCounter = 1;

    private string[,] helyek =
    {
        {"oneone", "twoone", "threeone", "" },
        {"onetwo", "twotwo", "threetwo", "" },
        {"onethree", "twothree", "threethree", "" },
        {"onefour", "twofour", "threefour", "" },
        {"", "", "", "" }
    };  

    void Start() {
        ap = FindObjectOfType<Akciopont>();      

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

    private void kezdoHelyMeghatarzoas() {
        int random = UnityEngine.Random.Range(1,12);
        Debug.Log("Random a kezdohelyszinhez: " + random);

        if(random == 1) {
            player.transform.position = oneone.transform.position;
            eromulepes1.SetActive(true);
            eromulepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 1;
            jelenlegi_y = 1;
        }
        else if(random == 2) {
            player.transform.position = twoone.transform.position;
            feketepiaclepes1.SetActive(true);
            feketepiaclepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 2;
            jelenlegi_y = 1;
        } else if (random == 3) {
            player.transform.position = threeone.transform.position;
            metrolepes1.SetActive(true);
            metrolepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 3;
            jelenlegi_y = 1;
        } else if (random == 4) {
            player.transform.position = onetwo.transform.position;
            szervereklepes1.SetActive(true);
            szervereklepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 1;
            jelenlegi_y = 2;
        } else if (random == 5) {
            player.transform.position = twotwo.transform.position;
            kingcasinolepes1.SetActive(true);
            kingcasinolepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 2;
            jelenlegi_y = 2;
        } else if (random == 6) {
            player.transform.position = threetwo.transform.position;
            feltoltolepes1.SetActive(true);
            feltoltolepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 3;
            jelenlegi_y = 2;
        } else if (random == 7) {
            player.transform.position = onethree.transform.position;
            kutatolaborlepes1.SetActive(true);
            kutatolaborlepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 1;
            jelenlegi_y = 3;
        } else if (random == 8) {
            player.transform.position = twothree.transform.position;
            kriptoklublepes1.SetActive(true);
            kriptoklublepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 2;
            jelenlegi_y = 3;
        } else if (random == 9) {
            player.transform.position = threethree.transform.position;
            cyberplazalepes1.SetActive(true);
            cyberplazalepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 3;
            jelenlegi_y = 3;
        } else if (random == 10) {
            player.transform.position = onefour.transform.position;
            hadiuzemlepes1.SetActive(true);
            hadiuzemlepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 1;
            jelenlegi_y = 4;
        } else if (random == 11) {
            player.transform.position = twofour.transform.position;
            konyvtarlepes1.SetActive(true);
            konyvtarlepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 2;
            jelenlegi_y = 4;
        } else if (random == 12) {
            player.transform.position = threefour.transform.position;
            korhazlepes1.SetActive(true);
            korhazlepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 3;
            jelenlegi_y = 4;
        }
    }

    // Update is called once per frame
    public void Update() {
        tavolsag = math.abs(tavolsag);

        // player mozgatása és konzolra iratás
        if (Input.GetKeyDown(KeyCode.Mouse0) && oneone_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[y, x].Equals("oneone")) {
                        Debug.Log("Player clicked on the collider: " + oneone_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));
                        if (eromulepes1.activeSelf == true & eromulepes2.activeSelf == true) {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else
                        {
                            if (tavolsag == 1 && ap.akciopont != 0)
                            {
                                    player.transform.position = oneone.transform.position;
                                    jelenlegi_x = 1;
                                    jelenlegi_y = 1;
                                    ap.akciopont = ap.akciopont - 1;
                                    oneonecount = oneonecount + 1;
                                    Debug.Log(ap.akciopont);
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
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mez?n belül akarsz lépni");
                            }
                        }
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && twoone_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[y, x].Equals("twoone")) {
                        Debug.Log("Player clicked on the collider: " + twoone_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));
                        if (feketepiaclepes1.activeSelf == true & feketepiaclepes2.activeSelf == true)
                        {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else
                        {
                            if (tavolsag == 1 && ap.akciopont != 0)
                            {
                                if (twoonecount < 2)
                                {
                                    player.transform.position = twoone.transform.position;
                                    jelenlegi_x = 2;
                                    jelenlegi_y = 1;
                                    ap.akciopont = ap.akciopont - 1;
                                    twoonecount = twoonecount + 1;
                                    Debug.Log(ap.akciopont);
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
                                }
                                else
                                {
                                    Debug.Log("Maximum kétszer léphetsz egy mez?re");
                                }
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mez?n belül akarsz lépni");
                            }
                        }
                        
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && threeone_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[y, x].Equals("threeone")) {
                        Debug.Log("Player clicked on the collider: " + threeone_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));
                        if (metrolepes1.activeSelf == true & metrolepes2.activeSelf == true)
                        {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else
                        {
                            if (tavolsag == 1 && ap.akciopont != 0)
                            {
                                if (threeonecount < 2)
                                {
                                    player.transform.position = threeone.transform.position;
                                    jelenlegi_x = 3;
                                    jelenlegi_y = 1;
                                    ap.akciopont = ap.akciopont - 1;
                                    threeonecount++;
                                    Debug.Log(ap.akciopont);
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
                                }
                                else
                                {
                                    Debug.Log("Maximum kétszer léphetsz egy mezõre");
                                }
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mez?n belül akarsz lépni");
                            }
                        }
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && onetwo_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[y, x].Equals("onetwo")) {
                        Debug.Log("Player clicked on the collider: " + onetwo_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));

                        if (szervereklepes1.activeSelf == true & szervereklepes2.activeSelf == true)
                        {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else
                        {
                            if (tavolsag == 1 && ap.akciopont != 0)
                            {
                                if (onetwocount < 2)
                                {
                                    player.transform.position = onetwo.transform.position;
                                    jelenlegi_x = 1;
                                    jelenlegi_y = 2;
                                    ap.akciopont = ap.akciopont - 1;
                                    onetwocount++;
                                    Debug.Log(ap.akciopont);
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
                                }
                                else
                                {
                                    Debug.Log("Maximum kétszer léphetsz egy mezõre");
                                }
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mezõn belül akarsz lépni");
                            }
                        }
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && twotwo_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[y, x].Equals("twotwo")) {
                        Debug.Log("Player clicked on the collider: " + twotwo_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));

                        if (kingcasinolepes1.activeSelf == true & kingcasinolepes2.activeSelf == true)
                        {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else {
                            if (tavolsag == 1 && ap.akciopont != 0)
                            {
                                if (twotwocount < 2)
                                {
                                    player.transform.position = twotwo.transform.position;
                                    jelenlegi_x = 2;
                                    jelenlegi_y = 2;
                                    ap.akciopont = ap.akciopont - 1;
                                    Debug.Log(ap.akciopont);
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
                                }
                                else
                                {
                                    Debug.Log("Maximum kétszer léphetsz egy mezõre");
                                }
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mezõn belül akarsz lépni");
                            }
                        }
                        
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && threetwo_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[y, x].Equals("threetwo")) {
                        Debug.Log("Player clicked on the collider: " + threetwo_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));

                        if (feltoltolepes1.activeSelf == true & feltoltolepes2.activeSelf == true)
                        {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else
                        {
                            if (tavolsag == 1 && ap.akciopont != 0)
                            {
                                if (threetwocount < 2)
                                {
                                    player.transform.position = threetwo.transform.position;
                                    jelenlegi_x = 3;
                                    jelenlegi_y = 2;
                                    ap.akciopont = ap.akciopont - 1;
                                    Debug.Log(ap.akciopont);
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
                                }
                                else
                                {
                                    Debug.Log("Maximum kétszer léphetsz egy mez?re");
                                }
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mez?n belül akarsz lépni");
                            }
                        }

                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && onethree_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[y, x].Equals("onethree")) {
                        Debug.Log("Player clicked on the collider: " + onethree_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));

                        if (kutatolaborlepes1.activeSelf == true & kutatolaborlepes2.activeSelf == true)
                        {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else
                        {
                            if (tavolsag == 1 && ap.akciopont != 0)
                            {
                                if (onethreecount < 2)
                                {
                                    player.transform.position = onethree.transform.position;
                                    jelenlegi_x = 1;
                                    jelenlegi_y = 3;
                                    ap.akciopont = ap.akciopont - 1;
                                    Debug.Log(ap.akciopont);
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
                                }
                                else
                                {
                                    Debug.Log("Maximum kétszer léphetsz egy mez?re");
                                }
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mez?n belül akarsz lépni");
                            }
                        }

                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && twothree_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[y, x].Equals("twothree")) {
                        Debug.Log("Player clicked on the collider: " + twothree_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));

                        if (kriptoklublepes1.activeSelf == true & kriptoklublepes2.activeSelf == true)
                        {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else
                        {
                            if (tavolsag == 1 && ap.akciopont != 0)
                            {
                                if (twothreecount < 2)
                                {
                                    player.transform.position = twothree.transform.position;
                                    jelenlegi_x = 2;
                                    jelenlegi_y = 3;
                                    ap.akciopont = ap.akciopont - 1;
                                    Debug.Log(ap.akciopont);
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
                                }
                                else
                                {
                                    Debug.Log("Maximum kétszer léphetsz egy mez?re");
                                }
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mez?n belül akarsz lépni");
                            }
                        }


                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && threethree_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[x, y].Equals("threethree")) {
                        Debug.Log("Player clicked on the collider: " + threethree_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));

                        if (cyberplazalepes1.activeSelf == true & cyberplazalepes2.activeSelf == true)
                        {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else
                        {
                            if (tavolsag == 1 && ap.akciopont != 0)
                            {
                                if (threethreecount < 2)
                                {
                                    player.transform.position = threethree.transform.position;
                                    jelenlegi_x = 3;
                                    jelenlegi_y = 3;
                                    ap.akciopont = ap.akciopont - 1;
                                    Debug.Log(ap.akciopont);
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
                                }
                                else
                                {
                                    Debug.Log("Maximum kétszer léphetsz egy mezõre");
                                }
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mez?n belül akarsz lépni");
                            }
                        }

                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && onefour_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[y, x].Equals("onefour")) {
                        Debug.Log("Player clicked on the collider: " + onefour_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));

                        if (hadiuzemlepes1.activeSelf == true & hadiuzemlepes2.activeSelf == true)
                        {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else
                        {
                            if (tavolsag == 1 && ap.akciopont != 0)
                            {
                                if (onefourcount < 2)
                                {
                                    player.transform.position = onefour.transform.position;
                                    jelenlegi_x = 1;
                                    jelenlegi_y = 4;
                                    ap.akciopont = ap.akciopont - 1;
                                    Debug.Log(ap.akciopont);
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
                                }
                                else
                                {
                                    Debug.Log("Maximum kétszer léphetsz egy mez?re");
                                }
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mez?n belül akarsz lépni");
                            }
                        }

                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && twofour_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[y, x].Equals("twofour")) {
                        Debug.Log("Player clicked on the collider: " + twofour_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));

                        if (konyvtarlepes1.activeSelf == true & konyvtarlepes2.activeSelf == true)
                        {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else
                        {
                            if (tavolsag == 1 && ap.akciopont != 0)
                            {
                                if (twofourcount < 2)
                                {
                                    player.transform.position = twofour.transform.position;
                                    jelenlegi_x = 2;
                                    jelenlegi_y = 4;
                                    ap.akciopont = ap.akciopont - 1;
                                    Debug.Log(ap.akciopont);
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
                                }
                                else
                                {
                                    Debug.Log("Maximum kétszer léphetsz egy mez?re");
                                }
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mez?n belül akarsz lépni");
                            }
                        }

                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && threefour_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[y, x].Equals("threefour")) {
                        Debug.Log("Player clicked on the collider: " + threefour_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));

                        if (korhazlepes1.activeSelf == true & korhazlepes2.activeSelf == true)
                        {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else
                        {
                            if (tavolsag == 1 && ap.akciopont != 0)
                            {
                                if (threefourcount < 2)
                                {
                                    player.transform.position = threefour.transform.position;
                                    jelenlegi_x = 3;
                                    jelenlegi_y = 4;
                                    ap.akciopont = ap.akciopont - 1;
                                    Debug.Log(ap.akciopont);
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
                                }
                                else
                                {
                                    Debug.Log("Maximum kétszer léphetsz egy mez?re");
                                }
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mez?n belül akarsz lépni");
                            }
                        }

                    }
                }
            }
        }

    }
}